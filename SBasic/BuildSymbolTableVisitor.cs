using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Parsing;
using SBasic.SymbolTable;
using static Parsing.SBasicParser;

namespace SBasic
{
    public class BuildSymbolTableVisitor<TResult>: GenericVisitor<TResult>, ISBasicVisitor<TResult> where TResult : notnull
    {
        private enum scopes { procedure, function, none };
        private SymbolTable<Symbol> SymbolTable { get; set; }
        private string FunctionScopeName { get; set; } = SymbolTable<Symbol>.Global;
        private scopes activeScopes { get; set; }

        private readonly ISet<string> ImplicitInts;
        private readonly ISet<string> ImplicitStrings;
        private ISet<string> References;
        public bool FirstPass { get; set; }

        public BuildSymbolTableVisitor(SymbolTable<Symbol> symbolTable)
        {
            SymbolTable = symbolTable;
            ImplicitInts = new HashSet<string>();
            ImplicitStrings = new HashSet<string>();
            References = new HashSet<string>();
        }

        public override TResult VisitTerminal([NotNull] ITerminalNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            bool funcProc = false;
            var payload = (CommonToken)node.Payload;

            if ((activeScopes != scopes.none) && FirstPass || (activeScopes == scopes.none) && !FirstPass)
            {
                string localScope;
                if ((activeScopes != scopes.none) && payload.Text != FunctionScopeName)
                {
                    localScope = FunctionScopeName;
                }
                else
                {
                    localScope = SymbolTable<Symbol>.Global;
                    if (FirstPass)
                    {
                        funcProc = true;
                    }
                }
                if (payload.Type == SBasicLexer.ID && (SymbolTable.ReadSymbol(payload.Text, FunctionScopeName).Item1) == SymbolStatus.Missing)
                {
                    var name = payload.Text;
                    var extracted = ExtractType(name);
                    name = extracted.Item1;
                    payload.Text = name;
                    var type = extracted.Item2;
                    Symbol symbol;
                    if (localScope == FunctionScopeName && localScope != SymbolTable<Symbol>.Global)
                    {
                        bool refer = References.Contains(name);
                        symbol = new ParamSymbol(name, type, localScope, refer);
                    }
                    else
                    {
                        if (funcProc)
                        {
                            int returnType = (activeScopes == scopes.procedure) ? SBasicLexer.DefProc : SBasicLexer.DefFunc;
                            symbol = new FuncSymbol(name, localScope, returnType, SBasicLexer.DefFunc);
                        }
                        else
                        {
                            symbol = new Symbol(name, localScope, type);
                        }
                    }
                    SymbolTable.AddSymbol(symbol.Name, symbol.Scope, symbol);
                }
            }
            return default;
        }

        public override TResult VisitDim([NotNull] SBasicParser.DimContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var paramList = (ParenthesizedlistContext)context.children[2].Payload;
            List<int> dimensions = (from node in paramList.children
                                    where node is LiteralExprContext
                                    let payload = (CommonToken)node.GetChild(0).Payload
                                    select Int32.Parse(payload.Text)).ToList();
            var name = (CommonToken)context.children[1].Payload;
            var extracted = ExtractType(name.Text);
            name.Text = extracted.Item1;
            var type = extracted.Item2;
            Symbol symbol = new ArraySymbol(name.Text, type, SymbolTable<Symbol>.Global, dimensions);
            SymbolTable.AddSymbol(symbol.Name, symbol.Scope, symbol);
            return base.VisitDim(context);
        }

        public override TResult VisitFuncDecl([NotNull] FuncDeclContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            string name = GetTextByType<SBasicParser.ProcedureNameContext>(context);
            FunctionScopeName = name;
            activeScopes = scopes.function;
            base.VisitFuncDecl(context);
            activeScopes = scopes.none;
            References = new HashSet<string>();
            return default;
        }

        public override TResult VisitProcDecl([NotNull] ProcDeclContext context)
        {
            var name = GetTextByType<SBasicParser.ProcedureNameContext>(context);
            FunctionScopeName = name;
            activeScopes = scopes.procedure;
            base.VisitProcDecl(context);
            activeScopes = scopes.none;
            References = new HashSet<string>();
            return default;
        }

        public override TResult VisitLoc([NotNull] LocContext context)
        {
            //            activeScopes = scopes.function;
            base.VisitLoc(context);
            //          FuncScopeActive = false;
            References = new HashSet<string>();
            return default;
        }

        // implicit lists are cumulative and never cleared
        public override TResult VisitImplicit([NotNull] ImplicitContext context)
        {
            if (FirstPass)
            {
                var implicitDecl = ((CommonToken)context.children[0].Payload).Text;
                var implicitType = ExtractType(implicitDecl);
                var subContext = (UnparenthesizedlistContext)context.children[1];
                foreach (var child in subContext.children)
                {
                    if (child is IdentExprContext)
                    {
                        var identCtx = ((IdentExprContext)child).children[0].Payload;
                        var terminalNode = ((IdentifierContext)identCtx).Payload.GetChild(0);
                        var name = ((TerminalNodeImpl)terminalNode).Payload.Text;
                        if (implicitType.Item2 == SBasicLexer.Integer)
                        {
                            ImplicitInts.Add(name);
                        }
                        else
                        {
                            ImplicitStrings.Add(name);
                        }

                    }
                }
               ((StmtlistContext)(context.Parent)).children = null;
            }
            return base.VisitImplicit(context);
        }

        public override TResult VisitReference([NotNull] ReferenceContext context)
        {
            if (FirstPass)
            {
                var subContext = (UnparenthesizedlistContext)context.children[1];
                foreach (var child in subContext.children)
                {
                    if (child is IdentExprContext)
                    {
                        var identCtx = ((IdentExprContext)child).children[0].Payload;
                        var terminalNode = ((IdentifierContext)identCtx).Payload.GetChild(0);
                        var name = ((TerminalNodeImpl)terminalNode).Payload.Text;
                        References.Add(name);
                    }
                }
               ((StmtlistContext)(context.Parent)).children = null;
            }
            return base.VisitReference(context);
        }

        private (string, int) ExtractType(string name)
        {
            if (ImplicitInts.Contains(name))
            {
                return (name, SBasicLexer.Integer);
            }

            if (ImplicitStrings.Contains(name))
            {
                return (name, SBasicLexer.String);
            }

            var type = SBasicLexer.Real;
            switch (name.Substring(name.Length - 1))
            {
                case "%":
                    type = SBasicLexer.Integer;
                    name = name[0..^1];
                    break;
                case "$":
                    type = SBasicLexer.String;
                    name = name[0..^1];
                    break;
            }
            return (name, type);
        }
    }
}

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
    //There are 6 ways to create a new name
    //    Dim
    //    Local
    //    Implicit
    //    assignment to it
    //    Define Procedure
    //    Define Function
    //    The last caan be followed by variable length parameter lists and dim by as dimensions list
    public class BuildSymbolTableVisitor<TResult>: GenericVisitor<TResult>, ISBasicVisitor<TResult> where TResult : notnull
    {
        private enum Scopes { procedure, function, none };
        private SymbolTable<Symbol> SymbolTable { get; set; }
        private string FunctionScopeName { get; set; } = SymbolTable<Symbol>.Global;
        private Scopes activeScopes { get; set; }

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
            //if (node == null)
            //    throw new ArgumentNullException(nameof(node));
            //bool funcProc = false;
            //var payload = (CommonToken)node.Payload;

            //if ((activeScopes != Scopes.none) && FirstPass || (activeScopes == Scopes.none) && !FirstPass)
            //{
            //    string localScope;
            //    if ((activeScopes != Scopes.none) && payload.Text != FunctionScopeName)
            //    {
            //        localScope = FunctionScopeName;
            //    }
            //    else
            //    {
            //        localScope = SymbolTable<Symbol>.Global;
            //        if (FirstPass)
            //        {
            //            funcProc = true;
            //        }
            //    }
            //    if (payload.Type == SBasicLexer.ID && (SymbolTable.ReadSymbol(payload.Text, FunctionScopeName).Item1) == SymbolStatus.Missing)
            //    {
            //        var name = payload.Text;
            //        var extracted = ExtractType(name);
            //        name = extracted.Item1;
            //        payload.Text = name;
            //        var type = extracted.Item2;
            //        Symbol symbol;
            //        if (localScope == FunctionScopeName && localScope != SymbolTable<Symbol>.Global)
            //        {
            //            bool refer = References.Contains(name);
            //            symbol = new ParamSymbol(name, type, localScope, refer);
            //        }
            //        else
            //        {
            //            if (funcProc)
            //            {
            //                int returnType = (activeScopes == Scopes.procedure) ? SBasicLexer.DefProc : SBasicLexer.DefFunc;
            //                symbol = new FuncSymbol(name, localScope, returnType, SBasicLexer.DefFunc);
            //            }
            //            else
            //            {
            //                symbol = new Symbol(name, localScope, type);
            //            }
            //        }
            //        SymbolTable.AddSymbol(symbol.Name, symbol.Scope, symbol);
            //    }
            //}
            return default;
        }

        public override TResult VisitDim([NotNull] SBasicParser.DimContext context)
        {
            for (int i = 0; i < context.ChildCount; i++)
            {
                ArrayNameContext nameContext = context.GetChild(i) as SBasicParser.ArrayNameContext;
                if (nameContext != null)
                {
                    var paramList = (ParenthesizedlistContext)context.children[i + 1].Payload;
                    List<int> dimensions = (from node in paramList.children
                                            where node is LiteralExprContext
                                            let payload = (CommonToken)node.GetChild(0).Payload
                                            select Int32.Parse(payload.Text)).ToList();
                    ArrayNameContext name = context.children[i].Payload as ArrayNameContext;
                    var extracted = ExtractType(name.GetText());
                    var trimmedName = extracted.Item1;
                    var type = extracted.Item2;
                    Symbol symbol = new ArraySymbol(trimmedName, type, SymbolTable<Symbol>.Global, dimensions);
                    SymbolTable.AddSymbol(symbol.Name, symbol.Scope, symbol);
                }
            }
            return base.VisitDim(context);
        }

        public override TResult VisitFuncDecl([NotNull] FuncDeclContext context)
        {
            //if (context == null)
            //{
            //    throw new ArgumentNullException(nameof(context));
            //}

            //string name = GetTextByType<SBasicParser.ProcedureNameContext>(context);
            //FunctionScopeName = name;
            //activeScopes = Scopes.function;
            //base.VisitFuncDecl(context);
            //activeScopes = Scopes.none;
            //References = new HashSet<string>();
            //return default;         
            return base.VisitFuncDecl(context);

        }
        public override TResult VisitProcedureName([NotNull] ProcedureNameContext context)
        {
            return base.VisitProcedureName(context);
        }
        public override TResult VisitProcDecl([NotNull] ProcDeclContext context)
        {
            FunctionScopeName = GetTextByType<SBasicParser.ProcedureNameContext>(context);
            //activeScopes = Scopes.procedure;
            //base.VisitProcDecl(context);
            //activeScopes = Scopes.none;
            //References = new HashSet<string>();
//            FunctionScopeName = SymbolTable<Symbol>.Global;
            return base.VisitProcDecl(context);
        }

        public override TResult VisitLocalVars([NotNull]LocalVarsContext context)
        {
            var unParContext = context.GetChild(2) as SBasicParser.UnparenthesizedlistContext;
            for (int i = 0; i < unParContext.ChildCount; i++)
            {
                IdentExprContext nameContext = unParContext.GetChild(i) as SBasicParser.IdentExprContext;
                if (nameContext != null)
                {
                    var extracted = ExtractType(nameContext.GetText());
                    var trimmedName = extracted.Item1;
                    var type = extracted.Item2;
                    Symbol symbol = new Symbol(trimmedName, FunctionScopeName, type);
                    SymbolTable.AddSymbol(trimmedName, FunctionScopeName, symbol);
                }
                else
                {
                    ArrayNameContext arrayNameContext = unParContext.GetChild(i) as SBasicParser.ArrayNameContext;
                    //List<int> dimensions = (from node in paramList.children
                    //                        where node is LiteralExprContext
                    //                        let payload = (CommonToken)node.GetChild(0).Payload
                    //                        select Int32.Parse(payload.Text)).ToList();

                }
            }
            FunctionScopeName = SymbolTable<Symbol>.Global;
            return base.VisitLocalVars(context);
        }

        // implicit lists are cumulative and never cleared
        public override TResult VisitImplicit([NotNull] ImplicitContext context)
        {
            var implicitDecl = ((CommonToken)context.GetChild(0).Payload).Text;
            UnparenthesizedlistContext unParContext = context.GetChild(1) as UnparenthesizedlistContext;
            var implicitType = ExtractType(implicitDecl);

            for (int i = 0; i < unParContext.ChildCount; i++)
            {
                IdentExprContext ident = unParContext.GetChild(i) as IdentExprContext;
                if (ident != null)
                {
                    var id = ident.GetText();
                    if (implicitType.Item2 == SBasicLexer.Integer)
                    {
                        ImplicitInts.Add(id);
                    }
                    else
                    {
                        ImplicitStrings.Add(id);
                    }
                }
            }
            return base.VisitImplicit(context);
        }

        public override TResult VisitReference([NotNull] ReferenceContext context)
        {
            //if (FirstPass)
            //{
            //    var subContext = (UnparenthesizedlistContext)context.children[1];
            //    foreach (var child in subContext.children)
            //    {
            //        if (child is IdentExprContext)
            //        {
            //            var identCtx = ((IdentExprContext)child).children[0].Payload;
            //            var terminalNode = ((IdentifierContext)identCtx).Payload.GetChild(0);
            //            var name = ((TerminalNodeImpl)terminalNode).Payload.Text;
            //            References.Add(name);
            //        }
            //    }
            //   ((StmtlistContext)(context.Parent)).children = null;
            //}
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

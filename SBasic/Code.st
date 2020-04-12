// Super Basic To C# Port of <programName> on <when>

public class SB
{
<if (reals)>
    public float <reals:{it|<it.Value.Name>};separator=", ">;        
<endif>
<if (realArrays)>
    public <realArrays:{it|float[] <it.Value.Name> = new float[<it.Value.dimensions:{ot|<ot>};separator=", ">];                 
    }>
<endif>
<if (integers)>
    public int <integers:{ut|<ut.Value.Name>};separator=", ">;        
    <endif>
<if (integerArrays)>
    public <integerArrays:{it|float[] <it.Value.Name> = new int[<it.Value.dimensions:{ot|<ot>};separator=", ">];
    }>
<endif>
<if (strings)>
    public string <strings:{ut|<ut.Value.Name>};separator=", ">;        
    <endif>
<if (stringArrays)>
    public <stringArrays:{it|float[] <it.Value.Name> = new string[<it.Value.dimensions:{ot|<ot>};separator=", ">];
    }>
<endif>


    public static void main()
    {
        
    }
}



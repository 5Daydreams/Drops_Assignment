using System;
using System.Collections.Generic;

[Serializable]
public class Stat
{
    private int baseValue;
    public int BaseValue
    {
        get
        {
            int finalValue = baseValue;
            modifiers.ForEach(x => finalValue +=x);
            return finalValue;
        }
        set => baseValue = value;
    }

    private List<int> modifiers = new List<int>();
    
    public void AddModifier(int modifier)
    {
        if(modifier != 0 )
            modifiers.Add(modifier);
    }
    
    public void RemoveModifier(int modifier)
    {
        if(modifier != 0 )
            modifiers?.Remove(modifier);
    }
}
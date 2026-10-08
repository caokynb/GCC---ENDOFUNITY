using System;
using UnityEngine;

public class Formula
{
    public int ScaleBasicStats(int stat,int level,int star)
    {
        return stat+(int)Math.Pow(level,1.05f)+(int)Math.Pow(star,1.2f);
    }
}

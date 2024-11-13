using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Mention
{
    TB,
    B,
    AB,
    P,
    I,
    AR
}

[System.Serializable]
public struct Bulletin
{
    public Bulletin(Mention l1 , Mention l2 , Mention l3 , Mention l4 , Mention l5 , Mention l6)
    {
        L1 = l1;
        L2 = l2;
        L3 = l3;
        L4 = l4;
        L5 = l5;
        L6 = l6;
    }
    
    public Mention L1, L2, L3, L4, L5, L6;

}
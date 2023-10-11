using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ItemSlot
{
    public int ID;
    public int Amount;

    public ItemSlot(int ID = -1, int Amount = 0) 
    {
        this.ID = ID;
        this.Amount = Amount;
    }

}

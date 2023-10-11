using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory Inventory;

#if UNITY_EDITOR
    public void OnValidate()
    {
        if (Inventory.slot.Length != Inventory.inventorySize)
        {
            var slots = Inventory.slot;

            Inventory.slot = new ItemSlot[Inventory.inventorySize];
            for(int i = 0; i < Inventory.inventorySize; i++)
            {
                if (slots.Length > i)
                    Inventory.slot[i] = new ItemSlot(slots[i].ID, slots[i].Amount);
                else 
                    Inventory.slot[i] = new ItemSlot(-1,0);
            }

        }
    }
#endif

}

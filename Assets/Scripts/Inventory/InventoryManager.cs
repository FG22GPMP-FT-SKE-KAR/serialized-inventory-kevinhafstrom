using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{

    public int potionsAmount = 0;

    [SerializeField]
    private FirebaseInventoryManager firebase;

    public UnityEvent<int> PotionsUpdated;

    private void Start()
    {
        firebase.LoadData();
    }

    public void UpdatePotionsCount()
    {
        if (PotionsUpdated != null) PotionsUpdated.Invoke(potionsAmount);
    }

    internal void AddPotion()
    {
        potionsAmount++;
        UpdatePotionsCount();
        firebase.SaveData();
    }

    internal bool RemovePotion()
    {
        if (potionsAmount - 1 < 0) return false;

        potionsAmount--;
        UpdatePotionsCount();
        firebase.SaveData();

        return true;
    }
}

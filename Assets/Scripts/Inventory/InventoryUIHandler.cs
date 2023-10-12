using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InventoryUIHandler : MonoBehaviour
{

    [Header("Potion")]
    [SerializeField]
    private TextMeshProUGUI _potionText;
    [Header("Inventory")]
    [SerializeField]
    private InventoryManager _inventoryManager;
    [Header("Timer")]
    [SerializeField]
    private TextMeshProUGUI _timerTimeText;
    [SerializeField]
    private TextMeshProUGUI _timerCooldownText;
    [SerializeField]
    private Timer _timer;

    public void UpdateText(int amount)
    {
        _potionText.text = amount.ToString("000");
    }

    public void Buy()
    {
        if (!_timer.IsTimer0()) return;

        _timer.SetTime(20).StartTimer(callback: (num) => 
            {
                _timerTimeText.text = num;
                if (num == "00")
                {
                    _timerCooldownText.gameObject.SetActive(false);
                }
                else
                {
                    _timerCooldownText.gameObject.SetActive(true);
                }
            }
        );

        _inventoryManager.AddPotion();
    }

    public void Sell()
    {
        _inventoryManager.RemovePotion();
    }

    public void Use()
    {
        _inventoryManager.RemovePotion();
    }
}

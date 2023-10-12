using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System.Threading.Tasks;

public class FirebaseInventoryManager : MonoBehaviour
{
    [Tooltip("Leave blank to generate ID from hardware")]
    [SerializeField]
    internal string _userID;

    [SerializeField]
    private InventoryManager _inventoryManager;

    private DatabaseReference _database;

    private void Awake()
    {
        if (_userID == "")
            _userID = SystemInfo.deviceUniqueIdentifier;
        _database = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public async void LoadData()
    {
        if (_database == null) return;

        var task = await _database.Child("users").Child(_userID).GetValueAsync();
        if (task != null)
        {
            string json = task.GetRawJsonValue();

            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            _inventoryManager.potionsAmount = playerData.PotionAmount;

            _inventoryManager.UpdatePotionsCount();
        }
        //string json = JsonUtility.FromJson<PlayerData>(b.ToString());
    }

    [ContextMenu("Test")]
    public void SaveData()
    {
        PlayerData t = new PlayerData(_inventoryManager.potionsAmount);

        string json = JsonUtility.ToJson(t);
        //Debug.Log(json);

        _database.Child("users").Child(_userID).SetRawJsonValueAsync(json);
    }

    [System.Serializable]
    private class PlayerData
    {
        public int PotionAmount;

        public PlayerData(int pots)
        {
            PotionAmount = pots;
        }
    }

}

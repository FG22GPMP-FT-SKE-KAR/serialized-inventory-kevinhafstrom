using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Firebase.Database;

public class FirebaseInventoryManager : MonoBehaviour
{
    [Tooltip("Leave blank to generate ID from hardware")]
    [SerializeField]
    internal string _userID;

    [SerializeField]
    private InventoryManager _inventoryManager;

    //private DatabaseReference _database;


    private void Start()
    {
        if (_userID == "")
            _userID = SystemInfo.deviceUniqueIdentifier;
        //_database = FirebaseDatabase.DefaultInstance.RootReference;
    }

    [ContextMenu("Test")]
    private void CreateUser()
    {
        Inventory inventory = _inventoryManager.Inventory;

        string json = JsonUtility.ToJson(inventory);
        Debug.Log(json);
    }

    private void UpdateUser()
    {

    }

}

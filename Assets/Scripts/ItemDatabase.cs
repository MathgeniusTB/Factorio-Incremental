using System.Collections.Generic;
using UnityEngine;
using static ItemSO;

public class ItemDatabase : MonoBehaviour {
    [SerializeField] private ScriptableObjectManager soManager;
    private List<ItemSO> loadedObjects;

    private void Awake() {
        loadedObjects = soManager.loadedObjects;
        RefreshDatabase();
    }

    public void RefreshDatabase() {
        foreach (var obj in loadedObjects) {
            if (obj.itemType == ItemType.Resource) {
                // Add resource to the database
                Debug.Log($"Resource added: {obj.itemName}");
            } else if (obj.itemType == ItemType.Building) {
                // Add machine to the database
                Debug.Log($"Machine added: {obj.itemName}");
            } else if (obj.itemType == ItemType.Miner) {
                // Add miner to the database
                Debug.Log($"Miner added: {obj.itemName}");
            }
        }
    }

    public List<ItemSO> GetAllItems() {
        return loadedObjects;
    }

    public List<ItemSO> GetItemsByType(ItemType type) {
        return loadedObjects.FindAll(item => item.itemType == type);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
    [SerializeField] private string itemsPath = "Assets/Data/ScriptableObjects/Items/Items/";
    public ItemSO[] items;

    private void Awake() {
        RefreshDatabase();
    }

    public void RefreshDatabase() {
        items = Resources.LoadAll<ItemSO>(itemsPath);
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Game/Item")]
public class ItemSO : ScriptableObject {
    public enum ItemState
    {
        Solid,
        Liquid
    }

    public enum ItemType {
        Resource,
        Building,
        Miner
    }

    public string itemName;
    public Sprite itemIcon;
    public float weight;
    public ItemState itemState;
    public ItemType itemType;
    public MinerSO miner;
    public BuildingSO building;
}

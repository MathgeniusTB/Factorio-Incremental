using UnityEngine;

public class GameResourceManager : MonoBehaviour
{
    // Singleton instance
    public static GameResourceManager Instance { get; private set; }
    
    // Reference to the item database
    [SerializeField] private ItemDatabase itemDatabase;
    
    // Player inventory
    [SerializeField] private Inventory playerInventory;
    
    
}

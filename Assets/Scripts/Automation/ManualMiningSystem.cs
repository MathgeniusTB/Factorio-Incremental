using UnityEngine;

public class ManualMiningSystem : MonoBehaviour {
    public Inventory resources;
    public ItemSO minedItem;

    public void Mine() {
        resources.AddItem(minedItem, 1);  // or based on mining speed
    }
}

using UnityEngine;

public class BuildSystem : MonoBehaviour {
    public AutomationManager automation;
    public Resources resources;

    public void PlaceMiner(ItemSO minerItem, ItemSO outputItem, float rate) {
        if (!resources.HasItem(minerItem, 1)) return;

        automation.miners.Add(new MinerInstance {
            outputItem = outputItem,
            outputRatePerSecond = rate
        });

        resources.RemoveItem(minerItem, 1);
    }

    public void PlaceMachine(ItemSO machineItem, RecipeSO recipe) {
        automation.machines.Add(new MachineInstance {
            currentRecipe = recipe,
            timer = 0f
        });

        resources.RemoveItem(machineItem, 1);
    }
}

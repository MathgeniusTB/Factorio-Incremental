using UnityEngine;

public class MinerInstance {
    public ItemSO outputItem;
    public float outputRatePerSecond;
    private float timer;

    public void Tick(float deltaTime, Inventory resources) {
        timer += deltaTime;
        if (timer >= 1f / outputRatePerSecond) {
            resources.AddItem(outputItem, 1);
            timer -= 1f / outputRatePerSecond;
        }
    }
}


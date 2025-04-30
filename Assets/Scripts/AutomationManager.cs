using System.Collections.Generic;
using UnityEngine;

public class AutomationManager : MonoBehaviour {
    public List<MinerInstance> miners;
    public List<MachineInstance> machines;
    public Resources resources;
    void Start() {
        miners = new List<MinerInstance>();
        machines = new List<MachineInstance>();
    }
    void Update() {
        float dt = Time.deltaTime;

        foreach (var miner in miners)
            miner.Tick(dt, resources);

        foreach (var machine in machines)
            machine.Tick(dt, resources);
    }
}


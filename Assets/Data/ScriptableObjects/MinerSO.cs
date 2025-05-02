using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewMiner", menuName = "Game/Miner")]
public class MinerSO : ScriptableObject {
    public string minerName;
    public Sprite icon;
    public ItemSO outputResource;
    public float outputRatePerSecond;
}

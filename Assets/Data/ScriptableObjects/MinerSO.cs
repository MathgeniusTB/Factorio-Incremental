using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewItem", menuName = "Game/Item")]
public class MinerSO : ScriptableObject {
    public string minerName;
    public Sprite icon;
    public ItemSO outputResource;
    public float outputRatePerSecond;
}

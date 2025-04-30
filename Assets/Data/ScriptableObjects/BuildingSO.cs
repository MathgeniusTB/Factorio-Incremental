using UnityEngine;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "Game/Building")]

public class BuildingSO : ScriptableObject
{
    public string buildingName;
    public Sprite icon;
    public float craftingSpeed;
    public float electricityConsumption;
}
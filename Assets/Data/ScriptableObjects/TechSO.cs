using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTech", menuName = "Game/Tech")]
public class TechSO : ScriptableObject {
  public List<TechSO> prerequisites;
  public List<RecipeSO> unlocks;
  public List<ItemStack> cost;
}
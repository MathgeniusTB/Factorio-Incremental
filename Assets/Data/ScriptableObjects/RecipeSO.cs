using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Game/Recipe")]
public class RecipeSO : ScriptableObject {
    public string recipeName;
    public ItemSO building;
    public List<ItemStack> inputs;
    public List<ItemStack> outputs;
    public float craftingTime;
}

[System.Serializable]
public class ItemStack {
    public ItemSO item;
    public int amount;

    // Constructor
    public ItemStack(ItemSO item, int amount) {
        this.item = item;
        this.amount = amount;
    }
}


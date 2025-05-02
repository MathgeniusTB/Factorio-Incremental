using System.Collections.Generic;
using System.ComponentModel;
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
public class ItemStack : INotifyPropertyChanged{
    public ItemSO item;
    private int _amount;
    public int amount
    {
        get => _amount;
        set
        {
            if (_amount != value)
            {
                _amount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(amount)));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    // Constructor
    public ItemStack(ItemSO item, int amount) {
        this.item = item;
        this.amount = amount;
    }
}


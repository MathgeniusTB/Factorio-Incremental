using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.IBindingExtensions; // Required for BindProperty and bindingContext


public class GameResourceManager : MonoBehaviour
{
    // Singleton instance
    public static GameResourceManager Instance { get; private set; }
    
    // Reference to the item database
    private ItemDatabase itemDatabase;
    
    // Player inventory
    private Inventory playerInventory;
    [Header("Default Starter Items")]
    [SerializeField] private List<ItemStack> starterItems;
    private UIDocument uIDocument;
    
    void Awake()
    {
        // Ensure only one instance of GameResourceManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            itemDatabase = GetComponent<ItemDatabase>();
            playerInventory = GetComponent<Inventory>();
            uIDocument = GetComponent<UIDocument>();
            playerInventory.AddItem(starterItems);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //add default items to the player inventory
        
    }

    private void OnEnable()
    {
        var root = uIDocument.rootVisualElement;
        var resourscesListView = root.Q<ListView>("ResourcesListView");
        
        resourscesListView.itemsSource = playerInventory.items;
        resourscesListView.makeItem = () =>
        {
            var itemAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                "Assets/UI/Documents/Item.uxml");
            return itemAsset.Instantiate();
        };
        resourscesListView.bindItem = (element, i) =>
        {
            var item = playerInventory.items[i];
            var currentitem = item.item;
            
            var nameLabel = element.Q<Label>("ItemName");
            var amountLabel = element.Q<Label>("ItemAmount");
            var actionButton = element.Q<Button>("ActionButton");

            nameLabel.text = item.item.itemName;
            amountLabel.text = item.amount.ToString();

            item.PropertyChanged -= (sender, e) => OnItemAmountChanged(sender, e, amountLabel);
            item.PropertyChanged += (sender, e) => OnItemAmountChanged(sender, e, amountLabel);

            actionButton.clicked -= null;
            
            if (item.item.canBeMined)
            {
                actionButton.text = "Mine";
                actionButton.clicked += () => Mine(currentitem);
            }
            else
            {
                actionButton.text = "Craft";
                actionButton.clicked += () => Craft(currentitem);
            }
        };
        resourscesListView.fixedItemHeight = 40; 
    }

    private void OnItemAmountChanged(object sender, PropertyChangedEventArgs e, Label amountLabel)
    {
        if (e.PropertyName == nameof(ItemStack.amount))
        {
            // Update the amountLabel text directly
            var itemStack = sender as ItemStack;
            if (itemStack != null)
            {
                amountLabel.text = itemStack.amount.ToString();
            }
        }
    }

    private void Mine(ItemSO item)
    {
        // Implement mining logic here
        Debug.Log($"Mining {item.itemName}");
        playerInventory.AddItem(item, 1);
    }
    private void Craft(ItemSO item)
    {
        // // Implement crafting logic here
        // Debug.Log($"Crafting {item.item.itemName}");
        // // Check if the player has enough resources to craft the item
        // if (playerInventory.HasItems(item.item.craftingRecipe))
        // {
        //     playerInventory.RemoveItems(item.item.craftingRecipe);
        //     playerInventory.AddItem(item.item, 1);
        // }
        // else
        // {
        //     Debug.Log("Not enough resources to craft " + item.item.itemName);
        // }
    }
}

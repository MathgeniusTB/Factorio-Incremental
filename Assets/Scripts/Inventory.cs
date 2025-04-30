using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemStack> items;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AddItem(ItemSO item, int amount) {
        // Check if the item already exists in the list
        ItemStack existingItem = items.Find(i => i.item == item);
        if (existingItem != null)
        {
            // If it exists, increase the amount
            existingItem.amount += amount;
        }
        else
        {
            // If it doesn't exist, create a new ItemStack and add it to the list
            ItemStack newItem = new ItemStack(item, amount);
            items.Add(newItem);
        }
    }
    public void AddItem(List<ItemStack> items) {
        foreach (ItemStack item in items)
        {
            // Check if the item already exists in the list
            ItemStack existingItem = this.items.Find(i => i.item == item.item);
            if (existingItem != null)
            {
                // If it exists, increase the amount
                existingItem.amount += item.amount;
            }
            else
            {
                // If it doesn't exist, create a new ItemStack and add it to the list
                ItemStack newItem = new ItemStack(item.item, item.amount);
                this.items.Add(newItem);
            }
        }
    }
    public bool HasItem(ItemSO item, int amount) {
        // Check if the item exists in the list
        ItemStack existingItem = items.Find(i => i.item == item);
        if (existingItem != null)
        {
            // If it exists, check if the amount is sufficient
            return existingItem.amount >= amount;
        }
        return false; // Item not found
    }
    public bool HasItems(List<ItemStack> requiredItems) {
        foreach (ItemStack requiredItem in requiredItems)
        {
            ItemStack existingItem = items.Find(i => i.item == requiredItem.item);
            if (existingItem == null || existingItem.amount < requiredItem.amount)
            {
                return false; // Not enough of the required item
            }
        }
        return true; // All required items are available
    }
    public void RemoveItems(List<ItemStack> requiredItems) {
        foreach (ItemStack requiredItem in requiredItems)
        {
            ItemStack existingItem = items.Find(i => i.item == requiredItem.item);
            if (existingItem != null)
            {
                existingItem.amount -= requiredItem.amount;
                if (existingItem.amount <= 0)
                {
                    items.Remove(existingItem);
                }
            }
        }
    }
    public void RemoveItem(ItemSO item, int amount) {
        // Check if the item exists in the list
        ItemStack existingItem = items.Find(i => i.item == item);
        if (existingItem != null)
        {
            // If it exists, decrease the amount
            existingItem.amount -= amount;
            if (existingItem.amount <= 0)
            {
                items.Remove(existingItem);
            }
        }
    }
}
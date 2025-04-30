using UnityEngine;

public class CraftingSystem : MonoBehaviour {
    public Resources resources;

    public void Craft(RecipeSO recipe) {

        if (resources.HasItems(recipe.inputs)) {
            resources.RemoveItems(recipe.inputs);
            resources.AddItem(recipe.outputs);
        }
    }
}

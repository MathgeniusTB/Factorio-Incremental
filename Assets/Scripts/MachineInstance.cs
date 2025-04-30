public class MachineInstance {
    public RecipeSO currentRecipe;
    public float timer;

    public void Tick(float deltaTime, Resources resources) {
        if (currentRecipe == null || !resources.HasItems(currentRecipe.inputs)) return;

        timer += deltaTime;
        if (timer >= currentRecipe.craftingTime) {
            resources.RemoveItems(currentRecipe.inputs);
            resources.AddItem(currentRecipe.outputs);
            timer -= currentRecipe.craftingTime;
        }
    }
}

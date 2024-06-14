using Application_Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application_Recipe
{
    // Added Calories section in the 'Display Recipe' method to display the information regarding calories
    public class Recipe
    {
        // Declare variables
        public List<string> Ingredients { get; set; }
        public List<string> recipeName { get; set; }
        public string FoodGroup { get; set; }
        public Ingredients ingredients;
        private Steps steps;
        private bool printSelectedRecipe; // Use as flag to track if '1. Display Recipe' option from the seleceted recipe menu list

        // Properties to store the food group and calories
        public string[] FoodGroups { get; set; }
        public int TotalCalories { get; set; }

        // Constructor -> Allows Recipe class to have access to the properties and methods of the Ingredients Class and Steps Class
        public Recipe(string name, string[] foodGroups, int totalCalories)
        {
            Ingredients = new List<string>();
            ingredients = new Ingredients();
            steps = new Steps();
            recipeName = new List<string>();
            printSelectedRecipe = true;

            // Initializing properties to accept addition parameters
            FoodGroups = foodGroups;
            TotalCalories = totalCalories;

            // Support the OnRecipeCaloriesExceed event to handle notifications
            ingredients.ExceedRecipeCalories += HandleExceedingRecipeCalories;
        }

        // Method to handle the notification when the total calories exceed 300
        private void HandleExceedingRecipeCalories(int totalCalories)
        {
            if (printSelectedRecipe)
            {
                Console.WriteLine($"\nThe total calories of the recipe {recipeName} exceed 300!");
            }
        }

        // Method to prompt user to enter recipe name
        public string GetRecipeName()
        {
            Console.Write("\nEnter the recipe name: ");
            string recipeName = Console.ReadLine();
            return recipeName;
        }

        // Method to ask user to enter input for the recipe details
        public void GetRecipeDetails()
        {
            ingredients.GetIngreDetails();
            steps.GetStepsDetails();

            // Method to collect recipe details
            Console.Write("\nEnter the food group: ");
            FoodGroup = Console.ReadLine();
        }

        // Method to print the the full recipe
        public void DisplayRecipe(string recipeName)
        {
            Console.WriteLine("\n-------- Recipe -------");
            Console.WriteLine("\nRecipe Name: " + recipeName);

            Console.WriteLine($"\n ***** {recipeName} recipe ingredients *****");
            ingredients.DisplayIngredients();

            int totalCalories = ingredients.GetTotalCalories();
            Console.WriteLine("\n***** Calories *****");
            // Display the message if the total calories exceed 300. Flag is resetted before displaying total calories
            printSelectedRecipe = false;
            Console.WriteLine("\nTotal Calories: " + totalCalories);
            // Call HandleRecipeCaloriesExceed only after displaying total calories
            HandleExceedingRecipeCalories(totalCalories);


            Console.WriteLine($"\n ***** {recipeName} recipe steps ***** ");
            steps.DisplaySteps();
        }

        // Method to scale the recipe ingredients by factors (0.5, 2, 3)
        public void RecipeScale()
        {
            Console.Write($"\n------ Scaling Factors of {recipeName} recipe ------\n0.5\n2\n3\nEnter the scaling factor of your choice:");
            double factor = Convert.ToDouble(Console.ReadLine());
            ingredients.IngredientsScale(factor);
        }
        // Method resetting the ingredient quantities to the original values
        public void QuantityReset()
        {
            Console.WriteLine($"\n----- Quantity Reset of {recipeName} recipe -----");
            ingredients.QuantityReset();
        }

        // Method to display the steps
        public void GetStepsDetails()
        {
            steps.GetStepsDetails();
        }

        // Method to check if the recipe meets filtering criteria
        public bool MatchesFilter(string ingredients, string foodGroup, int maxCalories)
        {
            return (ingredients == null || Ingredients.Contains(ingredients)) &&
                   (foodGroup == null || FoodGroups.Contains(foodGroup)) &&
                   (maxCalories == 0 || TotalCalories <= maxCalories);
        }

        // Method to clear the full recipe
        public void ClearRecipe()
        {
            ingredients.ClearIngredients();
            steps.ClearSteps();
        }
    }
}

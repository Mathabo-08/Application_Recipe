using Application_Recipe;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Application_Recipe
{
    // Modified the application from a single recipe application to a unlimited number of recipes application
    internal class Recipe_App
    {
        public static void Main(string[] args)
        {

            // Dictionary to store the recipes
            Dictionary<string, Recipe> recipes = new Dictionary<string, Recipe>();
            string recipeName = " ";

            // Loop through the main menu list 
            while (true)
            {
                Console.WriteLine("\n------- Main Menu -------");
                Console.WriteLine("\n****** Please choose an option from main menu ******");
                Console.WriteLine("\n1. Enter new recipe details");
                Console.WriteLine("\n2. Select a recipe from available recipes");
                Console.WriteLine("\n3  Filter recipes");
                Console.WriteLine("\n4. Exit");

                Console.Write("\nEnter your choice of option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Method to call the GetRecipeName 
                        Console.Write("\nEnter the recipe name: ");
                        recipeName = Console.ReadLine();

                        // Create new recipe and collect all the recipe details    
                        Recipe recipe = new Recipe(recipeName,new string[] { } ,0);
                        recipe.GetRecipeDetails();

                        // Add recipe to SortedDictionary
                        recipes.Add(recipeName, recipe);
                        break;
                    case "2":
                        // Select a recipe
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("\nPlease ensure that you enter the recipe details first, before displaying the recipe!");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("\n------- Available recipes -------");
                            int numRecipe = 1;
                            foreach (var name in recipes.Keys)
                            {
                                Console.WriteLine($"\n{numRecipe}.{name}");
                                numRecipe++;
                            }
                            Console.Write("\nEnter the name of the recipe you want to select: ");
                            string choosenRecipe = Console.ReadLine();


                            if (recipes.ContainsKey(key: choosenRecipe))
                            {

                                // Display selected menu
                                while (true)
                                {
                                    Console.WriteLine("\n------- Selected Recipe Menu -------");
                                    Console.WriteLine($"\n****** Please choose an option you want to view of '{choosenRecipe}' recipe ******");
                                    Console.WriteLine($"\n1. Display {choosenRecipe} recipe details");
                                    Console.WriteLine($"\n2. Scaling Factors of {choosenRecipe} recipe");
                                    Console.WriteLine($"\n3. Quantity Reset for {choosenRecipe} recipe");
                                    Console.WriteLine($"\n4. Clear {choosenRecipe} recipe");
                                    Console.WriteLine("\n5. Back to main menu");

                                    Console.Write("\nEnter your choice of option: ");
                                    string recipeSelectedChoice = Console.ReadLine();

                                    switch (recipeSelectedChoice)
                                    {
                                        case "1":

                                            // Displays recipe
                                            recipes[choosenRecipe].DisplayRecipe(choosenRecipe);
                                            break;

                                        case "2":
                                            // Method to call to scale the recipe by factors like 0.5, 2, 3
                                            recipes[choosenRecipe].RecipeScale();
                                            break;

                                        case "3":
                                            // Method to call to reset the quantities to the original values
                                            recipes[choosenRecipe].QuantityReset();
                                            break;

                                        case "4":
                                            // Method to call to clear the full recipe
                                            recipes[choosenRecipe].ClearRecipe();
                                            Console.WriteLine($"\nRecipe {choosenRecipe} successfully cleared!");
                                            break;

                                        case "5":
                                            // Back to main menu
                                            break;

                                        default:
                                            Console.WriteLine("\nInvalid choice.Please enter one of the choices from the list of options!");
                                            break;
                                    }
                                    if (recipeSelectedChoice == "5")
                                        Console.WriteLine("\nReturend to Main menu!"); break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nRecipe unavailable!");
                            }
                        }
                        break;

                    case "3":
                        // Filter recipes
                        FilterRecipes(recipes);
                        break;
                    case "4":
                        // exit the application
                        return;


                    default:
                        Console.WriteLine("\nInvalid choice.Please enter one of the choices from the list of options!");
                        break;

                }
            }
        }
        // Method to filter recipes by ingredient
        static List<Recipe> FilterByIngredient(Dictionary<string, Recipe> recipes, string ingredients)
        {
            return recipes.Values.Where(recipe => recipe.Ingredients.Contains(ingredients)).ToList();
        }

        // Method to filter recipes by food group
        static List<Recipe> FilterByFoodGroup(Dictionary<string, Recipe> recipes, string foodGroup)
        {
            return recipes.Values.Where(recipe => recipe.FoodGroup == foodGroup).ToList();
        }

        // Method to filter recipes by maximum calories
        static List<Recipe> FilterByMaxCalories(Dictionary<string, Recipe> recipes, int maxCalories)
        {
            return recipes.Values.Where(recipe => recipe.TotalCalories <= maxCalories).ToList();
        }

        // Method to handle filtering
        static void FilterRecipes(Dictionary<string, Recipe> recipes)
        {
            Console.WriteLine("\n------- Filter Recipes -------");
            Console.WriteLine("\n1. Filter by ingredient");
            Console.WriteLine("\n2. Filter by food group");
            Console.WriteLine("\n3. Filter by maximum calories");
            Console.WriteLine("\n4. Back to main menu");

            Console.Write("\nEnter your choice of option: ");
            string filterChoice = Console.ReadLine();

            switch (filterChoice)
            {
                case "1":
                    Console.Write("\nEnter the ingredient to filter by: ");
                    string ingredients = Console.ReadLine();
                    DisplayFilteredRecipes(FilterByIngredient(recipes, ingredients));
                    break;

                case "2":
                    Console.Write("\nEnter the food group to filter by: ");
                    string foodGroup = Console.ReadLine();
                    DisplayFilteredRecipes(FilterByFoodGroup(recipes, foodGroup));
                    break;

                case "3":
                    Console.Write("\nEnter the maximum calories to filter by: ");
                    int maxCalories = Convert.ToInt32(Console.ReadLine());
                    DisplayFilteredRecipes(FilterByMaxCalories(recipes, maxCalories));
                    break;

                case "4":
                    // Back to main menu
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Please enter one of the choices from the list of options!");
                    break;
            }
        }

        // Method to display filtered recipes
        static void DisplayFilteredRecipes(List<Recipe> filteredRecipes)
        {
            if (filteredRecipes.Count == 0)
            {
                Console.WriteLine("\nNo recipes found matching the criteria!");
            }
            else
            {
                Console.WriteLine("\n------- Filtered Recipes -------");
                foreach (var recipe in filteredRecipes)
                {
                    Console.WriteLine(recipe.recipeName);
                }
            }
        }
    }
}

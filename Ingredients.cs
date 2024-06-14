using Application_Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application_Recipe
{
    // Chaanged how Ingredient class is accessed from internal to public so that the unit test can access it
    public class Ingredients
    {
        // Declare array variables 
        private string[] ingredientName;
        private double[] origIngredientQuan;
        private double[] ingredientQuantity;
        private string[] ingredientUnitsMeasurement;
        public int[] ingredientCalories;
        private string[] ingredientFoodGroup;

        // Property to store food group of each ingredient
        public string[] FoodGroups { get; set; }

        // Delegate to notify the user when the total calories of a recipe exceed 300
        public delegate void RecipeCaloriesNotify(int totalCalories);

        // Event to be triggered when the total calories exceed 300
        public event RecipeCaloriesNotify ExceedRecipeCalories;

        // Method to prompt the user to enter the ingredient details
        public void GetIngreDetails()
        {
            Console.Write("\nEnter the number of ingredients: ");
            int ingredientNum = Convert.ToInt32(Console.ReadLine());

            ingredientName = new string[ingredientNum];
            ingredientQuantity = new double[ingredientNum];
            origIngredientQuan = new double[ingredientNum];
            ingredientUnitsMeasurement = new string[ingredientNum];
            // Method to prompt the user to enter the number of calories and the food group of each ingredient
            ingredientCalories = new int[ingredientNum];
            ingredientFoodGroup = new string[ingredientNum];

            for (int i = 0; i < ingredientNum; i++)
            {
                Console.Write("\nEnter the name of the Ingredient: ");
                ingredientName[i] = Console.ReadLine();

                Console.Write($"\nEnter the quantity of the ingredient (in decimal form) for {ingredientName[i]}: ");
                ingredientQuantity[i] = Convert.ToDouble(Console.ReadLine());

                // Store the original ingredient quantity
                origIngredientQuan[i] = ingredientQuantity[i];

                Console.Write($"\nEnter the unit of measurement for {ingredientName[i]}: ");
                ingredientUnitsMeasurement[i] = Console.ReadLine();

                // Array to store the number of calories and the food group of each ingredient
                Console.Write($"\nEnter the number of calories for {ingredientName[i]}: ");
                ingredientCalories[i] = Convert.ToInt32(Console.ReadLine());

                Console.Write($"\nEnter the food group that the {ingredientName[i]} belongs to: ");
                ingredientFoodGroup[i] = Console.ReadLine();

            }

            // Calculate total calories and trigger event if it exceeds 300
            int totalCalories = ingredientCalories.Sum();

            if (totalCalories > 300 && ExceedRecipeCalories != null)
            {
                ExceedRecipeCalories(totalCalories);
            }

        }

        // Method to print the ingredients
        public void DisplayIngredients()
        {
            for (int i = 0; i < ingredientName.Length; i++)
            {
                Console.WriteLine($"\nIngredient {i + 1}:  \n{"Ingredient Name: " + ingredientName[i]} \n{$"{ingredientName[i]} Quantity: " + ingredientQuantity[i]} \n{$"{ingredientName[i]} Unit of measurement: " + ingredientUnitsMeasurement[i]} \n{$"{ingredientName[i]} Number of Calories: " + ingredientCalories[i]} \n{$"{ingredientName[i]} Food group: " + ingredientFoodGroup[i]}");
            }
        }

        // Method to scale the ingredients quantities by factors (0.5, 2, 3)
        public void IngredientsScale(double factor)
        {
            Console.WriteLine("\n------ Scaled Ingredients ------");

            for (int i = 0; i < ingredientQuantity.Length; i++)
            {
                ingredientQuantity[i] *= factor;
            }
            DisplayIngredients();
        }

        // Method to reset the ingredients quantities to original values
        public void QuantityReset()
        {

            for (int i = 0; i < ingredientQuantity.Length; i++)
            {
                ingredientQuantity[i] = origIngredientQuan[i];
            }
            DisplayIngredients();
        }

        // Method to calculate the total calories of all the ingredients
        public int GetTotalCalories()
        {
            return ingredientCalories.Sum();
        }

        // Method to clear all the ingredients
        public void ClearIngredients()
        {
            ingredientName = null;
            ingredientQuantity = null;
            ingredientUnitsMeasurement = null;
            ingredientCalories = null;
            ingredientFoodGroup = null;
        }
    }
}

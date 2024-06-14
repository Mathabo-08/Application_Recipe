using Application_Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Recipe
{
    internal class Steps
    {
        // Declare instance variable
        private string[] stepsDescription;

        // Method to promt the user to enter the details of the steps
        public void GetStepsDetails()
        {
            Console.Write("\nEnter the number of steps: ");
            int stepsNum = Convert.ToInt32(Console.ReadLine());

            stepsDescription = new string[stepsNum];

            Console.WriteLine("\n------ Step description ------");

            for (int i = 0; i < stepsNum; i++)
            {
                Console.WriteLine($"\nStep {i + 1}:  ");
                stepsDescription[i] = Console.ReadLine();

            }

        }

        // Method to display all the steps
        public void DisplaySteps()
        {
            for (int i = 0; i < stepsDescription.Length; i++)
            {
                Console.WriteLine($"\n{i + 1}.{stepsDescription[i]}");
            }
        }

        // Method to clear all the steps
        public void ClearSteps()
        {
            stepsDescription = null;
        }
    }
}

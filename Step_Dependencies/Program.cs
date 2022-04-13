using System;


namespace Step_Dependencies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string item = @"C:\Users\Cortl\Source\Repos\step-dependencies-Cortlynd101\Step_Dependencies\PracticeFile.txt";
            StepDependency steps = new StepDependency(item);

            for (int i = 0; i < steps.stepsList.Count; i++)
            {
                steps.GetDependentOrder();
            }

            Console.WriteLine("The correct order is: ");
            for (int i = 0; i < steps.orderOfNonDependent.Length; i++)
            {
                if (i < steps.orderOfNonDependent.Length - 3)
                {
                    //Console.WriteLine(steps.orderOfNonDependent.Length);
                    Console.Write(steps.orderOfNonDependent[i] + " --> ");
                }
                else if (i < steps.orderOfNonDependent.Length - 2)
                {
                    Console.Write(steps.orderOfNonDependent[i]);
                }
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}

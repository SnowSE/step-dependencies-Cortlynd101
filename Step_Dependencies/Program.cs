using System;


namespace Step_Dependencies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string item = @"C:\Users\Cortl\Source\Repos\step-dependencies-Cortlynd101\Step_Dependencies\FinalInput.txt";
            StepDependency steps = new StepDependency(item);

            for (int i = 0; i < steps.stepsList.Count; i++)
            {
                steps.GetDependentOrder();
            }

            Console.WriteLine("The correct order is: ");
            for (int i = 0; i < steps.orderOfNonDependent.Length; i++)
            {
                if (i < 25)
                {
                    //Console.WriteLine(steps.orderOfNonDependent.Length);
                    Console.Write(steps.orderOfNonDependent[i] + " --> ");
                }
                else if (i < 26)
                {
                    Console.Write(steps.orderOfNonDependent[i]);
                }
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}

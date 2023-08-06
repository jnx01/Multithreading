using System;
using System.Diagnostics;
using System.Threading;

class PDCAssignment
{
    static int knapsack(int maxWeight, int[] weights, int[] values, int n)
    {
        if (maxWeight == 0 || n == 0)
        {
            return 0;
        }
        if (weights[n - 1] > maxWeight)
        {
            return knapsack(maxWeight, weights, values, (n - 1));
        }
        else
        {
            return Math.Max(values[n - 1] + knapsack(maxWeight - weights[n - 1], weights, values, (n - 1)),
                            knapsack(maxWeight, weights, values, (n - 1)));
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Starting serial execution");
        Stopwatch watch;
        watch = new Stopwatch();
        watch.Start();
        int[] weights = new int[] { 23, 26, 20, 18, 32, 27, 29, 26, 30, 27 };
        int[] values = new int[] { 505, 352, 458, 220, 354, 414, 498, 545, 473, 543 };
        int maxWeight = 67;
        int n = values.Length;
        int result = knapsack(maxWeight, weights, values, n);
        Console.WriteLine("Result: " + result);
        watch.Stop();
        Console.WriteLine("Serial Execution Time: " + watch.Elapsed.Milliseconds.ToString() + "ms");
        Console.WriteLine("Ending serial execution");
    }
}








using System.Diagnostics;
using System.Threading;

class PDCAssignment
{
    static int knapsack(int maxWeight, int[] weights, int[] values, int n)
    {
        if (maxWeight == 0 || n == 0)
        {
            return 0;
        }
        if (weights[n - 1] > maxWeight)
        {
            return knapsack(maxWeight, weights, values, (n - 1));
        }
        else
        {
            return Math.Max(values[n - 1] + knapsack(maxWeight - weights[n - 1], weights, values, (n - 1)),
                            knapsack(maxWeight, weights, values, (n - 1)));
        }
    }

    static void driverProgram()
    {
        object result = 0;
        int[] weights = new int[] { 23, 26, 20, 18, 32, 27, 29, 26, 30, 27 };
        int[] values = new int[] { 505, 352, 458, 220, 354, 414, 498, 545, 473, 543 };
        int maxWeight = 67;
        int n = values.Length;
        result = knapsack(maxWeight, weights, values, n);
        Console.WriteLine("Result: " + result);
        Console.WriteLine("Aborting Child Thread");
        Thread.CurrentThread.Interrupt(); //Abort() function has become obsolete
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Parent Thread Started");
        Stopwatch watch;
        watch = new Stopwatch();
        watch.Start();
        Thread.CurrentThread.Name = "Parent";
        Console.WriteLine("Creating Child Thread");
        Thread knapsackSolution = new Thread(driverProgram);
        knapsackSolution.Start();
        if (Thread.CurrentThread.Name == "Parent")
        {
            knapsackSolution.Join();
        }
        watch.Stop();
        Console.WriteLine("Total Execution Time (with Thread object and with Join operation): " +
                            watch.Elapsed.Milliseconds.ToString() + "ms");
        Console.WriteLine("Parent Thread Ending");
    }
}









using System.Diagnostics;
using System.Threading;

class PDCAssignment
{
    static int knapsack(int maxWeight, int[] weights, int[] values, int n)
    {
        if (maxWeight == 0 || n == 0)
        {
            return 0;
        }
        if (weights[n - 1] > maxWeight)
        {
            return knapsack(maxWeight, weights, values, (n - 1));
        }
        else
        {
            return Math.Max(values[n - 1] + knapsack(maxWeight - weights[n - 1], weights, values, (n - 1)),
                            knapsack(maxWeight, weights, values, (n - 1)));
        }
    }

    static void driverProgram()
    {
        object result = 0;
        int[] weights = new int[] { 23, 26, 20, 18, 32, 27, 29, 26, 30, 27 };
        int[] values = new int[] { 505, 352, 458, 220, 354, 414, 498, 545, 473, 543 };
        int maxWeight = 67;
        int n = values.Length;
        result = knapsack(maxWeight, weights, values, n);
        Console.WriteLine("Result: " + result);
        Console.WriteLine("Aborting Child Thread");
        Thread.CurrentThread.Interrupt(); //Abort() function has become obsolete
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Parent Thread Started");
        Stopwatch watch;
        watch = new Stopwatch();
        watch.Start();
        Console.WriteLine("Creating Child Thread");
        Thread knapsackSolution = new Thread(driverProgram);
        knapsackSolution.Start();
        watch.Stop();
        Console.WriteLine("Total Execution Time (with Thread object and with Join operation): " +
                            watch.Elapsed.Milliseconds.ToString() + "ms");
        Console.WriteLine("Parent Thread Ending");
    }
}

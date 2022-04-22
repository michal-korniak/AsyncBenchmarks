using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncBenchmarks;

public static class FibonacciBenchmarks
{
    public static int CalculateFibonacciNumber(int n)
    {
        if (n == 1 || n == 2)
        {
            return 1;
        }
        else
        {
            return CalculateFibonacciNumber(n - 1) + CalculateFibonacciNumber(n - 2);
        }
    }

    public static async Task<int> CalculateFibonacciNumberWithTaskCompletedTask(int n)
    {
        await Task.CompletedTask;
        if (n == 1 || n == 2)
        {
            return 1;
        }
        else
        {
            return await CalculateFibonacciNumberWithTaskCompletedTask(n - 1) + await CalculateFibonacciNumberWithTaskCompletedTask(n - 2);
        }
    }

    public static async Task<int> CalculateFibonacciNumberWithTaskYield(int n)
    {
        await Task.Yield();
        if (n == 1 || n == 2)
        {
            return 1;
        }
        else
        {
            return await CalculateFibonacciNumberWithTaskYield(n - 1) + await CalculateFibonacciNumberWithTaskYield(n - 2);
        }
    }

    public static async Task<int> CalculateFibonacciNumberWithTaskRun(int n)
    {
        return await Task.Run(async () =>
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return await CalculateFibonacciNumberWithTaskRun(n - 1) + await CalculateFibonacciNumberWithTaskRun(n - 2);
            }
        });

    }
}

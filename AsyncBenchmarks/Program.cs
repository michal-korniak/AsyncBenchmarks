using System.Diagnostics;

namespace AsyncBenchmarks;
public class Program
{
    public static async Task Main()
    {
        await ExecuteFibonacciBenchmarks(7, 1000);
        Console.WriteLine("\n_______________________________\n");
        await ExecuteSigmaBenchmarks(10000, 10000);
        Console.WriteLine("\n_______________________________\n");
        Console.WriteLine("Finished");
        Console.ReadKey();
    }

    private static async Task ExecuteFibonacciBenchmarks(int fibonacciNumberToBeCalculated, int numberOfRetries)
    {
        Console.WriteLine("Fibonacci benchmark");
        Console.WriteLine($"Fibonacci number to be calculated: {fibonacciNumberToBeCalculated}");
        Console.WriteLine($"Number of retries: {numberOfRetries}");
        Console.WriteLine();

        TimeSpan syncBenchmarkResult = Executors.ExecuteSyncBenchmark(() => FibonacciBenchmarks.CalculateFibonacciNumber(fibonacciNumberToBeCalculated), numberOfRetries);
        Console.WriteLine($"Sync benchmark: {syncBenchmarkResult.TotalMilliseconds} ms");

        TimeSpan taskCompletedTaskBenchmarkResult = await Executors.ExecuteAsyncBenchmark(async () => { await FibonacciBenchmarks.CalculateFibonacciNumberWithTaskCompletedTask(fibonacciNumberToBeCalculated); }, numberOfRetries);
        Console.WriteLine($"Task.CompletedTask benchmark: {taskCompletedTaskBenchmarkResult.TotalMilliseconds} ms");

        TimeSpan taskYieldBenchmarkResult = await Executors.ExecuteAsyncBenchmark(async () => { await FibonacciBenchmarks.CalculateFibonacciNumberWithTaskYield(fibonacciNumberToBeCalculated); }, numberOfRetries);
        Console.WriteLine($"Task.Yield() benchmark: {taskYieldBenchmarkResult.TotalMilliseconds} ms");

        TimeSpan taskRunBenchmarkResult = await Executors.ExecuteAsyncBenchmark(async () => { await FibonacciBenchmarks.CalculateFibonacciNumberWithTaskRun(fibonacciNumberToBeCalculated); }, numberOfRetries);
        Console.WriteLine($"Task.Run() benchmark: {taskRunBenchmarkResult.TotalMilliseconds} ms");
    }

    private static async Task ExecuteSigmaBenchmarks(int numberToBeCalculated, int numberOfRetries)
    {
        Console.WriteLine("Sigma benchmark");
        Console.WriteLine($"Sigma number to be calculated: {numberToBeCalculated}");
        Console.WriteLine($"Number of retries: {numberOfRetries}");
        Console.WriteLine();

        TimeSpan syncBenchmarkResult = Executors.ExecuteSyncBenchmark(() => SigmaBenchmarks.CalculateSigma(numberToBeCalculated), numberOfRetries);
        Console.WriteLine($"Sync benchmark: {syncBenchmarkResult.TotalMilliseconds} ms");

        TimeSpan taskFromResultTaskBenchmarkResult = await Executors.ExecuteAsyncBenchmark(async () => { await SigmaBenchmarks.CalculateSigmaWithTaskFromResult(numberToBeCalculated); }, numberOfRetries);
        Console.WriteLine($"Task.FromResult benchmark: {taskFromResultTaskBenchmarkResult.TotalMilliseconds} ms");

        TimeSpan taskCompletedTaskBenchmarkResult = await Executors.ExecuteAsyncBenchmark(async () => { await SigmaBenchmarks.CalculateSigmaWithTaskCompletedTask(numberToBeCalculated); }, numberOfRetries);
        Console.WriteLine($"Task.CompletedTask benchmark: {taskCompletedTaskBenchmarkResult.TotalMilliseconds} ms");

        TimeSpan taskYieldBenchmarkResult = await Executors.ExecuteAsyncBenchmark(async () => { await SigmaBenchmarks.CalculateSigmaWithTaskYield(numberToBeCalculated); }, numberOfRetries);
        Console.WriteLine($"Task.Yield() benchmark: {taskYieldBenchmarkResult.TotalMilliseconds} ms");

        TimeSpan taskRunBenchmarkResult = await Executors.ExecuteAsyncBenchmark(async () => { await SigmaBenchmarks.CalculateSigmaWithTaskRun(numberToBeCalculated); }, numberOfRetries);
        Console.WriteLine($"Task.Run() benchmark: {taskRunBenchmarkResult.TotalMilliseconds} ms");
    }

}

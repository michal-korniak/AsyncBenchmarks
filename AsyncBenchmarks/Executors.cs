using System.Diagnostics;

namespace AsyncBenchmarks
{
    public class Executors
    {
        public static TimeSpan ExecuteSyncBenchmark(Action action, int numberOfRetries)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numberOfRetries; ++i)
            {
                action.Invoke();
            }
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public static async Task<TimeSpan> ExecuteAsyncBenchmark(Func<Task> action, int numberOfRetries)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numberOfRetries; ++i)
            {
                await action.Invoke();
            }
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}

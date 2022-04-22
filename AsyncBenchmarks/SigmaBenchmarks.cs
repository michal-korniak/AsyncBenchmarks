namespace AsyncBenchmarks
{
    public static class SigmaBenchmarks
    {
        public static int CalculateSigma(int number)
        {
            int sum = 0;
            for (int i = 0; i < number; ++i)
            {
                sum += i;
            }
            return sum;
        }

        public static async Task<int> CalculateSigmaWithTaskYield(int number)
        {
            await Task.Yield();
            int sum = 0;
            for (int i = 0; i < number; ++i)
            {
                sum += i;
            }
            return sum;
        }

        public static async Task<int> CalculateSigmaWithTaskRun(int number)
        {
            return await Task.Run(() =>
            {
                int sum = 0;
                for (int i = 0; i < number; ++i)
                {
                    sum += i;
                }
                return sum;
            });
        }

        public static async Task<int> CalculateSigmaWithTaskCompletedTask(int number)
        {
            await Task.CompletedTask;
            int sum = 0;
            for (int i = 0; i < number; ++i)
            {
                sum += i;
            }
            return sum;
        }

        public static Task<int> CalculateSigmaWithTaskFromResult(int number)
        {
            int sum = 0;
            for (int i = 0; i < number; ++i)
            {
                sum += i;
            }
            return Task.FromResult(sum);
        }
    }
}

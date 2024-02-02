namespace Structure.Persistence.DependencyInjection.Options
{
    public record SqlServerRetryOptions
    {
        public int MaxRetryCount { get; set; }
        public TimeSpan MaxRetryDelay { get; set; }
        public int[]? ErrorNumbersToAdd { get; set; }
    }
}
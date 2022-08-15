namespace BackgroundJobs.Abstract
{
    public interface IJobs
    {
        //void DelayedJob(string to, string content, TimeSpan timeSpan);
        void FireAndForget(string to, string content);
    }
}

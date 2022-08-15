using System;
using BackgroundJobs.Abstract;
using DTO.User;

namespace BackgroundJobs.Concrete.HangfireJobs
{
    public class HangfireJobs : IJobs
    {
        private IMailService _mailService;

        public HangfireJobs(IMailService mailService)
        {
            _mailService = mailService;
        }

        //public void DelayedJob(string to, string content, TimeSpan timeSpan)
        //{
        //    Hangfire.BackgroundJob.Schedule(() =>
        //            _mailService.SendPasswordService(to, content), timeSpan);
        //}

        public void FireAndForget(string to, string content)
        {
            Hangfire.BackgroundJob.Enqueue(() =>
                    _mailService.PasswordService(to, content));
        }
    }
}

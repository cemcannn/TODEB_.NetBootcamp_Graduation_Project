using System;

namespace Business.Configuration.Helper
{
    public class Generator
    {
        public static string PasswordGenerator(int length)
        {
            return Guid.NewGuid().ToString().Substring(1, length);
        }
    }
}

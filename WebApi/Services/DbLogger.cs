namespace WebApi.Services
{
    public class DbLogger : ILoggerService
    {
        public void Write(string message)
        {
            System.Console.WriteLine("[DBLogger] - " + message);
        }
    }
}
namespace clu.aspnet.webapplication.mvc.core.Services
{
    public interface IMyService
    {
        void DoSomething();

        string ReturnSomething();
    }

    public class MyService : IMyService
    {
        public void DoSomething()
        {

        }

        public string ReturnSomething()
        {
            return "Hello World!";
        }
    }

    public interface IFirstService
    {
        string GoFirst();
    }

    public interface ISecondService
    {
        string GoSecond();
    }

    public class FirstService : IFirstService
    {
        public string GoFirst()
        {
            return "Going first";
        }
    }

    public class SecondService : ISecondService
    {
        private IFirstService _firstService;

        public SecondService(IFirstService firstService)
        {
            _firstService = firstService;
        }

        public string GoSecond()
        {
            return $"{_firstService.GoFirst()} - Going Second";
        }
    }
}
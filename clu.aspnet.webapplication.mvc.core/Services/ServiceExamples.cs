using System;

namespace clu.aspnet.webapplication.mvc.core.Services
{
    public class BadExample
    {
        public class MyClass
        {
            private MyDependency _myDependency;

            public MyClass(MyDependency myDependency)
            {
                _myDependency = myDependency;
            }
        }

        public class MyDependency
        {
            private MySubDependency _mySubDependency;

            public MyDependency(MySubDependency mySubDependency)
            {
                _mySubDependency = mySubDependency;
            }
        }

        public class MySubDependency
        {
            public MySubDependency()
            {

            }
        }

        public class SomeClass
        {
            public SomeClass()
            {
                MySubDependency mySubDependency = new MySubDependency();
                MyDependency myDependency = new MyDependency(mySubDependency);
                MyClass myClass = new MyClass(myDependency);
            }
        }
    }

    public class GoodExample
    {
        public interface IMyClass
        {

        }

        public interface IMyDependency
        {

        }

        public interface IMySubDependency
        {

        }

        public class MyClass : IMyClass
        {
            private IMyDependency _myDependency;

            public MyClass(IMyDependency myDependency)
            {
                _myDependency = myDependency;
            }
        }

        public class MyDependency : IMyDependency
        {
            private IMySubDependency _mySubDependency;

            public MyDependency(IMySubDependency mySubDependency)
            {
                _mySubDependency = mySubDependency;
            }
        }

        public class MySubDependency : IMySubDependency
        {
            public MySubDependency()
            {

            }
        }

        public class SomeClass
        {
            private IMyClass _myClass;

            public SomeClass(IMyClass myClass)
            {
                _myClass = myClass;
            }
        }
    }

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
            return "Hello from service";
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

    public interface IRandomService
    {
        int GetNumber();
    }

    public class RandomService : IRandomService
    {
        private int _randomNumber;

        public RandomService()
        {
            Random random = new Random();
            _randomNumber = random.Next(1000000);
        }
        public int GetNumber()
        {
            return _randomNumber;
        }
    }

    public interface IRandomWrapper
    {
        int GetNumber();
    }

    public class RandomWrapper : IRandomWrapper
    {
        private IRandomService _randomService;

        public RandomWrapper(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public int GetNumber()
        {
            return _randomService.GetNumber();
        }
    }

    public interface ILogger
    {
        void LogInformation(string message);
    }

    public class Logger : ILogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IFormatNumber
    {
        string GetFormattedNumber(int number);
    }

    public class FormatNumber : IFormatNumber
    {
        public string GetFormattedNumber(int number)
        {
            return string.Format("{0:n0}", number);
        }
    }
}
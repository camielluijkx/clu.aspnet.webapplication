namespace clu.aspnet.webapplication.mvc.core.Services
{
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
}
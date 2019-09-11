namespace clu.aspnet.webapplication.mvc.core.Services
{
    public class SomeClass
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

        public SomeClass()
        {
            MySubDependency mySubDependency = new MySubDependency();
            MyDependency myDependency = new MyDependency(mySubDependency);
            MyClass myClass = new MyClass(myDependency);
        }
    }
}
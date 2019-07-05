using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Source;

namespace Tests
{
    [TestClass]
    public class FooUnitTests
    {
        [TestMethod]
        public void Foo_DoSomething_StateVerification_ConcreteStub()
        {
            //Setup
            var awesome = "Awesome!!";
            var dependency = new DependencyStub();
            var foo = new Foo(dependency);

            //Exercise
            foo.DoSomething(awesome);

            //Verify
            Assert.AreEqual(awesome, dependency.Value, $"Expected Value to be {awesome} but was {dependency.Value}.");

            //Teardown handled by the garbage collector
        }

        [TestMethod]
        public void Foo_DoSomething_StateVerification_ProxyStub()
        {
            //Setup
            var awesome = "Awesome!!";
            var dependency = new Mock<IDependency>();
            var foo = new Foo(dependency.Object);

            dependency.SetupProperty(d => d.Value); // tracks the Value property

            //Exercise
            foo.DoSomething(awesome);

            //Verify
            Assert.AreEqual(awesome, dependency.Object.Value, $"Expected Value to be {awesome} but was {dependency.Object.Value}.");

            //Teardown handled by the garbage collector
        }
    }
}

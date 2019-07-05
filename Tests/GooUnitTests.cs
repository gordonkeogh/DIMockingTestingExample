using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Source;

namespace Tests
{
    [TestClass]
    public class GooUnitTests
    {
        [TestMethod]
        public void Goo_DoSomething_Valid_CallsSend()
        {
            //Setup
            var awesome = "Awesome!!";
            var dependency1 = new Mock<IDependency1>();
            var dependency2 = new Mock<IDependency2>();
            var goo = new Goo(dependency1.Object, dependency2.Object);

            dependency1.Setup(d1 => d1.IsValid(It.Is<string>(p => p == awesome))).Returns(true); // set condition

            //Exercise
            goo.DoSomething(awesome);

            //Verify
            dependency1.Verify(d1 => d1.IsValid(It.Is<string>(p => p == awesome)), Times.Exactly(1), $"Expected IsValid() to be called passing {awesome} as a parameter exactly once but wasn't."); 
            dependency2.Verify(d2 => d2.Send(It.Is<string>(p => p == awesome)), Times.Exactly(1), $"Expected Send() to be called passing {awesome} as a parameter exactly once but wasn't."); 

            //Teardown handled by the garbage collector
        }

        [TestMethod]
        public void Goo_DoSomething_NotValid_DoesNotCallsSend()
        {
            //Setup
            var awesome = "Awesome!!";
            var dependency1 = new Mock<IDependency1>();
            var dependency2 = new Mock<IDependency2>();
            var goo = new Goo(dependency1.Object, dependency2.Object);

            dependency1.Setup(d1 => d1.IsValid(It.Is<string>(p => p == awesome))).Returns(false); // set condition

            //Exercise
            goo.DoSomething(awesome);

            //Verify
            dependency1.Verify(d1 => d1.IsValid(It.Is<string>(p => p == awesome)), Times.Exactly(1), $"Expected IsValid() to be called passing {awesome} as a parameter exactly once but wasn't.");
            dependency2.Verify(d2 => d2.Send(It.IsAny<string>()), Times.Never, $"Did not expect Send() to be called but was.");

            //Teardown handled by the garbage collector
        }
    }
}

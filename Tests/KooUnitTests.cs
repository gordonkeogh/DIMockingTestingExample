using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Source;

namespace Tests
{
    [TestClass]
    public class KooUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(KooException), "Expected a KooException to be thrown but was not.")]
        public void Koo_DoSomething_ExceptionCaught_KooExceptionThrown()
        {
            //Setup
            var awesome = "Awesome!!";
            var dependency1 = new Mock<IDependency1>();
            var dependency2 = new Mock<IDependency2>();
            var koo = new Koo(dependency1.Object, dependency2.Object);

            dependency1.Setup(d1 => d1.IsValid(It.Is<string>(p => p == awesome))).Returns(true); // set condition
            dependency2.Setup(d2 => d2.Send(It.Is<string>(p => p == awesome))).Throws(new Exception("Something really bad happened.")); // set condition

            //Exercise
            koo.DoSomething(awesome);

            //Verify
            dependency1.Verify(d1 => d1.IsValid(It.Is<string>(p => p == awesome)), Times.Exactly(1), $"Expected IsValid() to be called passing {awesome} as a parameter exactly once but wasn't."); 
            dependency2.Verify(d2 => d2.Send(It.Is<string>(p => p == awesome)), Times.Exactly(1), $"Expected Send() to be called passing {awesome} as a parameter exactly once but wasn't."); 

            //Teardown handled by the garbage collector
        }
    }
}

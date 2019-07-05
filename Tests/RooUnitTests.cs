using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Source;

namespace Tests
{
    [TestClass]
    public class RooUnitTests
    {
        [TestMethod]
        public async Task Roo_DoSomething_AsyncDependencyCalled()
        {
            //Setup
            var awesome = "Awesome!!";
            var dependency = new Mock<IDependency3>();
            var roo = new Roo(dependency.Object);

            dependency.Setup(d1 => d1.IsValid(It.Is<string>(p => p == awesome))).ReturnsAsync(true); // set condition

            //Exercise
            var result = await roo.DoSomething(awesome);

            //Verify
            dependency.Verify(d1 => d1.IsValid(It.Is<string>(p => p == awesome)), Times.Exactly(1), $"Expected IsValid() to be called passing {awesome} as a parameter exactly once but wasn't."); 

            Assert.IsTrue(result, $"Expected true to be returned but was {result}");
            //Teardown handled by the garbage collector
        }
    }
}

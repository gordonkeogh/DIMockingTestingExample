using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Source;

namespace Tests
{
    [TestClass]
    public class BarUnitTests
    {
        [TestMethod]
        public void Bar_DoSomething_MockMethod()
        {
            //Setup
            var awesome = "Awesome!!";
            var bar = new Mock<Bar>();

            bar.Setup(b => b.IsValid(It.Is<string>(p => p == awesome))).Returns(true);

            //Exercise
            var result = bar.Object.DoSomething(awesome);

            //Verify
            bar.Verify(b => b.IsValid(It.Is<string>(p => p == awesome)), Times.Exactly(1), $"Expected IsValid() to be called passing {awesome} as a parameter exactly once but wasn't.");
            
            Assert.AreEqual("Valid", result, $"Expected result to be Valid but was {result}.");
            
            //Teardown handled by the garbage collector
        }
    }
}

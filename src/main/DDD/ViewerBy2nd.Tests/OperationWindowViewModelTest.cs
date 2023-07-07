using ViewerBy2nd.WinFormsControlLibrary;

namespace ViewerBy2nd.Tests
{
    [TestClass]
    public class OperationWindowViewModelTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            OperationWindowViewModel model = new();
            model.WindowSize = WindowSize.Standard;
            Assert.AreEqual(1, model.WindowSize);
        }
    }

    internal class OperationWindowViewModel
    {
    }
}
      


}

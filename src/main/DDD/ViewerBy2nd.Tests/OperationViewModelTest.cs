using ViewerBy2nd.WinFormsControlLibrary;

namespace ViewerBy2nd.Tests
{
    [TestClass]
    public class OperationViewModelTest
    {
        private OperationViewModel _viewModel;

        [TestInitialize]
        public void SetUp()
        {
            _viewModel = new OperationViewModel();
        }

        [TestMethod]
        public void TestMethod1()
        {
            OperationViewModel model = new();
            string file = "testfile.pdf";
            model.AddFiles(new List<string> { file });
            Assert.AreEqual(1, model.FileList.Count);
            Assert.AreEqual("testfile.pdf", model.FileList[0].FileName);


        }
   
        [TestMethod]
        public void AddFile_RaisesFileListChangedEvent()
        {
            var eventRaised = false;
            _viewModel.FileListChanged += () => eventRaised = true;

            _viewModel.AddFiles(new List<string> { "testfile" });

            Assert.IsTrue(eventRaised, "FileListChanged event was not raised after adding a file");
        }
    }

}
      




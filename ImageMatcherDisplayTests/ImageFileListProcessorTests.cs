using ImageMatcherDisplay;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageMatcherDisplayTests
{
    [TestClass()]
    public class ImageFileListProcessorTests
    {
        [TestMethod()]
        public void ProcessFolderTest_Load_One_Image_Returns_List_Of_One()
        {
            var imageFileProcessor = new ImageFileListProcessor();
            var listImageFile = imageFileProcessor.ProcessFolder(@"..\..\TestImages\Test1");
            Assert.AreEqual(1,listImageFile.Count);
        }

        [TestMethod()]
        public void ProcessFolderTest_Load_Multiple_Images_Return_List_Of_Six()
        {
            var imageFileProcessor = new ImageFileListProcessor();
            var listImageFile = imageFileProcessor.ProcessFolder(@"..\..\TestImages\Test2");
            Assert.AreEqual(6, listImageFile.Count);
        }
    }
}
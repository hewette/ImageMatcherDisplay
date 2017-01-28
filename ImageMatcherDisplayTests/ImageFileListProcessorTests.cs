using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageMatcherDisplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMatcherDisplay.Tests
{
    [TestClass()]
    public class ImageFileListProcessorTests
    {
        [TestMethod()]
        public void ProcessFolderTest_Load_One_Image_Returns_List_Of_One()
        {
            ImageFileListProcessor imageFileProcessor = new ImageFileListProcessor();
            var ListImageFile = imageFileProcessor.ProcessFolder(@"..\..\TestImages\Test1");
            Assert.AreEqual(1,ListImageFile.Count);
        }

        [TestMethod()]
        public void ProcessFolderTest_Load_Multiple_Images_Return_List_Of_Six()
        {
            ImageFileListProcessor imageFileProcessor = new ImageFileListProcessor();
            var ListImageFile = imageFileProcessor.ProcessFolder(@"..\..\TestImages\Test2");
            Assert.AreEqual(6, ListImageFile.Count);
        }
    }
}
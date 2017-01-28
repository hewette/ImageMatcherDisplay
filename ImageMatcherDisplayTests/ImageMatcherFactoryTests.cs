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
    public class ImageMatcherFactoryTests
    {
        private ImageMatcherFactory imageMatcherFactory;
        [TestInitialize]
        public void Init_Tests()
        {
            imageMatcherFactory = new ImageMatcherFactory();
        }
        [TestMethod()]
        public void PrepareImageFileListTest_PrepareImageList_Returns_Not_Null()
        {
            imageMatcherFactory.PrepareImageFileList(@"..\..\TestImages\Test1");
            Assert.IsNotNull(imageMatcherFactory.ListImageFile);
        }
    
        [TestMethod()]
        public void GetListImageFilesandNamesTest_Get_Prepared_List_Returns_List_Of_Six_Images()
        {
            imageMatcherFactory.PrepareImageFileList(@"..\..\TestImages\Test2");
            var ItemsSource = imageMatcherFactory.GetListImageFilesandNames();
            Assert.AreEqual(6,ItemsSource.Count);
        }
    }
}

//TODO increase test coverage
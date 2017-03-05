using ImageMatcherDisplay;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
namespace ImageMatcherDisplayTests
{
    [TestClass()]
    public class ImageMatcherFactoryTests
    {
        private ImageMatcherFactory _imageMatcherFactory;
        [TestInitialize]
        public void Init_Tests()
        {
            _imageMatcherFactory = new ImageMatcherFactory();
        }
        [TestMethod()]
        public void PrepareImageFileListTest_PrepareImageList_Returns_Not_Null()
        {
            _imageMatcherFactory.PrepareImageFileList(@"..\..\TestImages\Test1");
            Assert.IsNotNull(_imageMatcherFactory.ListImageFile);
        }
    
        //[TestMethod()]
        //public void GetListImageFilesandNamesTest_Get_Prepared_List_Returns_List_Of_Six_Images()
        //{
        //    _imageMatcherFactory.PrepareImageFileList(@"..\..\TestImages\Test2");
        //    var itemsSource = _imageMatcherFactory.GetListImageFilesandNames();
        //    Assert.AreEqual(6,itemsSource.Count);
        //}
    }
}

//TODO increase test coverage
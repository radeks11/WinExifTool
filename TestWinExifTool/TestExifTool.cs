using NUnit.Framework;
using WinExifTool.Utils;

namespace TestWinExifTool
{
    public class TestExifTool
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGroupFileList()
        {
            System.Collections.Generic.List<string> paths = new System.Collections.Generic.List<string>( new string[] { "file01.jpg", "file02.jpg", "file03.jpg", "file04.jpg", "file05.jpg", "file06.jpg", "file07.jpg" } );
            ExifTool exifTool = new ExifTool();
            System.Collections.Generic.List<System.Collections.Generic.List<string>> groups = exifTool.GroupFileList(paths, 3);
            Assert.AreEqual(groups.Count, 3, "Iloœæ grup ma byæ 3");
            Assert.AreEqual(groups[2][0], "file07.jpg");

            Assert.Pass();
        }


    }
}
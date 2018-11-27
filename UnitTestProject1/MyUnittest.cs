using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KlaitonUnitTests.KlaitonProject;

namespace KlaitonMainProjectTest
{
    /// <summary>
    /// Summary description for MyUnittest
    /// </summary>
    [TestClass]
    public class MyUnittest
    {

        [TestMethod]
        public void MyClassTest_Create()
        {
            IInterface obj = new MyClass();
            Assert.IsNotNull(obj);
        }

        //write other unittest to find the bugs 
        [TestMethod()]
        public void GetBorderTimeTest()
        {
            Assert.Fail();
        }


        //which test are necessary to 100% code coverage (test all the function)
        [DataRow(BorderRange.Day)]
        [DataRow(BorderRange.Month)]
        [DataRow(BorderRange.Year)]
        [DataRow(null)]
        [DataTestMethod()]
        public void GetHighBorderTest(BorderRange borderRange)
        {
            MyClass obj = new MyClass();

            DateTime dateToTest = obj.GetHighBorder(DateTime.Now, borderRange);
            Assert.IsNotNull(dateToTest);
            switch (borderRange)
            {
                case BorderRange.Day:
                    Assert.Equals(dateToTest, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1));
                    break;
                case BorderRange.Month:
                    Assert.Equals(dateToTest, new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 0)); ;
                    // Or, assuming the code is correct: 
                    // Assert.ThrowsException<NotSupportedException>(() => { obj.GetHighBorder(DateTime.Now, borderRange); });
                    break;
                case BorderRange.Year:
                    Assert.Equals(dateToTest, new DateTime(DateTime.Now.Year + 1, 0, 0)); ;
                    break;
            }
        }

        [DataRow(BorderRange.Day)]
        [DataRow(BorderRange.Month)]
        [DataRow(BorderRange.Year)]
        [DataRow(null)]
        [DataTestMethod()]
        public void GetLowBorderTest(BorderRange borderRange)
        {
            MyClass obj = new MyClass();

            DateTime dateToTest = obj.GetLowBorder(DateTime.Now, borderRange);
            DateTime dateToTest2 = obj.GetLowBorder(new DateTime(1984, 4, 8), borderRange); 
            Assert.IsNotNull(dateToTest);

            switch (borderRange)
            {
                case BorderRange.Day:
                    Assert.Equals(dateToTest, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
                    Assert.Equals(dateToTest2, new DateTime(1984, 4, 8));
                    break;
                case BorderRange.Month:
                    Assert.Equals(dateToTest, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 0));
                    Assert.Equals(dateToTest2, new DateTime(1984, 4, 0));
                    break;
                case BorderRange.Year:
                    Assert.Equals(dateToTest, new DateTime(DateTime.Now.Year, 0, 0));
                    Assert.Equals(dateToTest2, new DateTime(1984, 0, 0));
                    break;
            }
        }
    }
}

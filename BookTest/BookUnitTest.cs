using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OBL_Opgave;

namespace BookTest
{
    [TestClass]
    public class BookUnitTest
    {
        public Book TestBook = new Book("testBogen", "LangtNavn",12,"a123456789101");
        // Dette vil jeg argumentere for at være en test af hvorvidt constructoren fungerer korrekt til at oprette book objekter, hvis parametrene er korrekt udfyldte

        [TestMethod]
        public void TestIsbn13()
        {
            
            string TestIsbn = "b123456789910";
            TestBook.ISBN13 = TestIsbn;
            Assert.AreEqual(TestBook.ISBN13, TestIsbn);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIsbn13OutOfRange()
        {
            TestBook.ISBN13 = "10ab";
        }

        [TestMethod]
        public void TestTitel()
        {
            string newTitle = "nyTitel";
            TestBook.Titel = newTitle;

            Assert.AreEqual(TestBook.Titel, newTitle);
        }

        [TestMethod]
        public void TestForfatter()
        {
            string NyForfatter = "NyForfatter";

            TestBook.Forfatter = NyForfatter;

            Assert.AreEqual(NyForfatter, TestBook.Forfatter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestForfatterKortereEnd2tegn()
        {
            TestBook.Forfatter = "a";
        }

        [TestMethod]
        public void TestSidetal()
        {
            int NytSidetal = 14;

            TestBook.Sidetal = NytSidetal;

            Assert.AreEqual(NytSidetal, TestBook.Sidetal);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSidetalUnder4()
        {
            TestBook.Sidetal = 2;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSidetalOver1000()
        {
            TestBook.Sidetal = 1001;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IncorrectConstructorTest()
        {
            Book testbook2 = new Book("Titel2","forfatter",11,"abc123");
        }

    }
}

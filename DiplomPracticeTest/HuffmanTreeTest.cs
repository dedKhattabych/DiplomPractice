using DiplomPractice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiplomPractice
{
    [TestClass]
    public class HuffmanTreeTest
    {
        [TestMethod]
        public void Test()
        {
            HuffmanTree tree = new HuffmanTree();
            string testExample = "EEEBBBCCDA";
            var resEn = tree.HuffmanCodeEncode(testExample);
            var resDe = tree.HuffmanCodeDecode(resEn);
            Assert.AreEqual(testExample, resDe);

            HuffmanTree tree1 = new HuffmanTree();
            string geeksForGeeksExamp = "aaaaabbbbbbbbbccccccccccccdddddddddddddeeeeeeeeeeeeeeeefffffffffffffffffffffffffffffffffffffffffffff";
            var resEn1 = tree1.HuffmanCodeEncode(geeksForGeeksExamp);
            var resDe1 = tree1.HuffmanCodeDecode(resEn1);
            Assert.AreEqual(geeksForGeeksExamp, resDe1);

            HuffmanTree tree2 = new HuffmanTree();
            string longText = "The task of the organization, especially the beginning of daily work on the formation of a position, plays an important role in the formation of significant financial and administrative conditions. Similarly, consultation with a broad asset allows you to perform important tasks for the development of a development model. Comrades!";
            var resEn2 = tree2.HuffmanCodeEncode(longText);
            var resDe2 = tree2.HuffmanCodeDecode(resEn2);
            Assert.AreEqual(longText, resDe2);

            HuffmanTree tree3 = new HuffmanTree();
            string allUniq = "jadoe";
            string resEn3 = tree3.HuffmanCodeEncode("jadoe");
            var resDe3 = tree3.HuffmanCodeDecode(resEn3);
            Assert.AreEqual(allUniq, resDe3);
        }
    }
}

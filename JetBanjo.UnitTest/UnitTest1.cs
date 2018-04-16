using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using JetBanjo.Utils;

namespace JetBanjo.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<CImage> l1 = new List<CImage>();
            l1.Add(new CImage("JetBanjo.Resources.error.png"));
            l1.Add(new CImage("JetBanjo.Resources.badair.png"));
            List<CImage> l2 = new List<CImage>();
            l2.Add(new CImage("JetBanjo.Resources.error.png"));
            l2.Add(new CImage("JetBanjo.Resources.badair.png"));
            
            Assert.IsTrue(l1.SequenceEqual(l2));
        }


    }
}

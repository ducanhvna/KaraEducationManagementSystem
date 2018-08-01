using Microsoft.VisualStudio.TestTools.UnitTesting;
using KaraMongoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaraMongoModelNS;

namespace KaraMongoModel.Tests
{
    [TestClass()]
    public class SimpleTests
    {
        [TestMethod()]
        public void ConnectTest()
        {
            Simple.Connect();
        }
    }
}
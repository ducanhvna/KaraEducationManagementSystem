using Microsoft.VisualStudio.TestTools.UnitTesting;
using KaraMongoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraMongoModel.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void ConnectTest()
        {
            Class1.Connect();
        }
    }
}
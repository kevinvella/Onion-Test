using EFCore.Services.Cryptography.Hashing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Services.UnitTest
{
    [TestClass]
    public class MD5CryptographyServiceUnitTest
    {
        [TestMethod]
        public void HashStringUnitTest()
        {
            string data = "testing123456789!";
            string preHashedString = "F582DBED972F9BECC1FEC7041E491578";

            MD5CryptographyService service = new MD5CryptographyService();

            string hashedString = service.Hash(data);

            Assert.AreEqual(preHashedString, hashedString);
        }
    }
}

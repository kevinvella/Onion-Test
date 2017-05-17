using EFCore.Services.Cryptography.Hashing;
using EFCore.Services.Interfaces.Cryptography.Hashing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Services.UnitTest
{
    [TestClass]
    public class CryptographyServiceUnitTest
    {
        ICryptographyService md5Service;
        ICryptographyService sha256Service;
        ICryptographyService sha512Service;

        string theData;

        [TestInitialize]
        public void Setup()
        {
            md5Service = new MD5CryptographyService();
            sha256Service = new SHA256CryptographyService();
            sha512Service = new SHA512CryptographyService();

            theData = "testing123456789!";
        }

        [TestMethod]
        public void MD5HashValidUnitTest()
        {
            string preHashedString = "F582DBED972F9BECC1FEC7041E491578";

            string hashedString = md5Service.Hash(theData);

            Assert.AreEqual(preHashedString, hashedString);
        }

        [TestMethod]
        public void SHA256HashValidUnitTest()
        {
            string preHashedString = "3AA4E132908961CC3D988D0248943F9354342A190652851E01B5F83ABCFF5FBB";

            string hashedString = sha256Service.Hash(theData);

            Assert.AreEqual(preHashedString, hashedString);
        }

        [TestMethod]
        public void SHA512HashValidUnitTest()
        {
            string preHashedString = "CC0F7D2D77B9AA277F85227E12B688BB9EBDD975CEF1CD98DAA328C6086822BCB93FC8A602AED3CC078FB4B68044040EB3353434BCCD92FD5F70545C1BD32724";

            string hashedString = sha512Service.Hash(theData);

            Assert.AreEqual(preHashedString, hashedString);
        }
    }
}

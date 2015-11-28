﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rubberduck.Katas.Network.Tests
{
    [TestClass]
    public class Ip4AddressTests
    {
        [TestMethod]
        public void CanCreateFromString()
        {
            Ip4Address ip = new Ip4Address("192.10.1.1");

            Assert.AreEqual(192, ip.Octet1);
            Assert.AreEqual(10, ip.Octet2);
            Assert.AreEqual(1, ip.Octet3);
            Assert.AreEqual(1, ip.Octet4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenStringHasSpaces_ThrowsArgException()
        {
            new Ip4Address("1 . 2 . 3 . 4");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenStringIsMalformed_ThrowsArgException()
        {
            new Ip4Address("10.10.1..");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenStringHasAlphaChars_ThrowsArgException()
        {
            new Ip4Address("10.10.A.1");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void WhenByteArrayArgIsNull_ThrowsNullArgException()
        {
            new Ip4Address((byte[])null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenStringArgIsNull_ThrowsNullArgException()
        {
            new Ip4Address((string)null);
        }

        [TestMethod]
        public void CanCreateFromByteArray()
        {
            var ip = new Ip4Address(new byte[] {192, 10, 1, 1});

            Assert.AreEqual(192, ip.Octet1);
            Assert.AreEqual(10, ip.Octet2);
            Assert.AreEqual(1, ip.Octet3);
            Assert.AreEqual(1, ip.Octet4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ByteArrayLengthCannotBeLessThan4()
        {
            new Ip4Address(new byte[] {});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ByteArrayLengthCannotBeGreaterThan4()
        {
            new Ip4Address(new byte[] {1, 1, 1, 1, 1});
        }

        [TestMethod]
        public void CanCreateFromBaseTenAddress()
        {
            //i.e. can create from an integer.
            var ip = new Ip4Address(UInt32.MaxValue); //0xFFFFFFFF

            Assert.AreEqual(255, ip.Octet1);
            Assert.AreEqual(255, ip.Octet2);
            Assert.AreEqual(255, ip.Octet3);
            Assert.AreEqual(255, ip.Octet4);
        }

        [TestMethod]
        public void ToStringReturnsExpectedResult()
        {
            var ip = new Ip4Address(new byte[] {10, 10, 1, 1});

            Assert.AreEqual("10.10.1.1", ip.ToString());
        }

        [TestMethod]
        public void WhenTwoIpAddressesAreTheSame_TheyAreEqual()
        {
            var ip1 = new Ip4Address("10.10.1.1");
            var ip2 = new Ip4Address("10.10.1.1");

            //Assert.AreEqual calls Object.Equals(Object), so test both IEquatable & Object.Equals override.
            Assert.IsTrue(ip1.Equals(ip2));
            Assert.AreEqual(ip1, ip2);
            Assert.IsTrue(ip1 == ip2);
        }

        [TestMethod]
        public void WhenTwoIpAddressesAreNotTheSame_TheyAreNotEqual()
        {
            var ip1 = new Ip4Address("10.10.1.1");
            var ip2 = new Ip4Address("192.10.1.1");

            //Assert.AreEqual calls Object.Equals(Object), so test both IEquatable & Object.Equals override.
            Assert.IsFalse(ip1.Equals(ip2));
            Assert.AreNotEqual(ip1, ip2);
            Assert.IsFalse(ip1 == ip2);
        }

        [TestMethod]
        public void CompareTo_GreaterThan()
        {
            var ip1 = new Ip4Address("10.10.0.1");
            var ip2 = new Ip4Address("10.9.1.2");

            Assert.AreEqual(1, ip1.CompareTo(ip2));
        }

        [TestMethod]
        public void CompareTo_LessThan()
        {
            var ip1 = new Ip4Address("10.9.1.2");
            var ip2 = new Ip4Address("10.10.0.0");

            Assert.AreEqual(-1, ip1.CompareTo(ip2));
        }

        [TestMethod]
        public void CompareTo_Equal()
        {
            var ip1 = new Ip4Address("10.10.1.1");
            var ip2 = new Ip4Address("10.10.1.1");

            Assert.AreEqual(0,ip1.CompareTo(ip2));
        }
    }
}
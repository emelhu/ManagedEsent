﻿//-----------------------------------------------------------------------
// <copyright file="RetinfoTests.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

namespace InteropApiTests
{
    using Microsoft.Isam.Esent.Interop;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// JET_RETINFO tests
    /// </summary>
    [TestClass]
    public class RetinfoTests
    {
        /// <summary>
        /// Test conversion to the native stuct
        /// </summary>
        [TestMethod]
        public void ConvertToNativeTest()
        {
            var retinfo = new JET_RETINFO();
            retinfo.ibLongValue = 1;
            retinfo.itagSequence = 2;

            var native = retinfo.GetNativeRetinfo();
            Assert.AreEqual<uint>(1, native.ibLongValue);
            Assert.AreEqual<uint>(2, native.itagSequence);
        }

        /// <summary>
        /// Test conversion from the native stuct
        /// </summary>
        [TestMethod]
        public void ConvertFromNativeTest()
        {
            var native = new NATIVE_RETINFO();
            native.columnidNextTagged = 257;

            var retinfo = new JET_RETINFO();
            retinfo.SetFromNativeRetinfo(native);

            Assert.AreEqual<uint>(257, retinfo.columnidNextTagged.Value);
        }

        /// <summary>
        /// Test conversion to a native struct andback again
        /// </summary>
        [TestMethod]
        public void RoundTripConversionTest()
        {
            var retinfo = new JET_RETINFO();
            retinfo.ibLongValue = 1;
            retinfo.itagSequence = 2;

            var native = retinfo.GetNativeRetinfo();
            native.columnidNextTagged = 300;

            retinfo.SetFromNativeRetinfo(native);
            Assert.AreEqual(1, retinfo.ibLongValue);
            Assert.AreEqual(2, retinfo.itagSequence);
            Assert.AreEqual<uint>(300, retinfo.columnidNextTagged.Value);
        }
    }
}
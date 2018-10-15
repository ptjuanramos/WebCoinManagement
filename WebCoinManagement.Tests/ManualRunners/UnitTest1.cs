using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebCoinManagement.Models;

namespace WebCoinManagement.Tests.ManualRunners {

    [TestClass]
    public class UnitTest1 {
        private static readonly ILog logger = LogManager.GetLogger(typeof(UnitTest1));

        [TestMethod]
        public void TestMethod1() {
        }

        [TestMethod]
        public void FetchUserData() {
            CoinManagementContext coinManagementContext = new CoinManagementContext();
            List<Users> usersList = coinManagementContext.Users.ToList();
            foreach(Users user in usersList) {
                Debug.WriteLine("Name of the user: " + user.Name);
            }
        }
    }
}

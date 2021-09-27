using DevTeams_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Komodo_Tests
{
    [TestClass]
    public class POCO_Tests
    {
        [TestMethod]
        public void SetFirst_ShouldBeCorrect()
        {
            Developer dev = new Developer();

            dev.FirstName = "Jesse";

            string expected = "Jesse";
            string actual = dev.FirstName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetLast_ShouldBeCorrect()
        {
            Developer dev = new Developer();

            dev.LastName = "South";

            string expected = "South";
            string actual = dev.LastName;
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetID_ShouldBeCorrect()
        {
            Developer dev = new Developer();

            dev.IDNumber = 12345;

            int expected = 12345;
            int actual = dev.IDNumber;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetAccess_ShouldBeCorrect()
        {
            Developer dev = new Developer();

            dev.AccessToPluralsight = true;

            bool expected = true;
            bool actual = dev.AccessToPluralsight;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetTeamName_ShouldBeCorrect()
        {
            DevTeam team = new DevTeam();

            team.TeamName = "Warriors";

            string expected = "Warriors";
            string actual = team.TeamName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetTeamID_ShouldBeCorrect()
        {
            DevTeam team = new DevTeam();

            team.TeamID = 54321;

            int expected = 54321;
            int actual = team.TeamID;

            Assert.AreEqual(expected, actual);
        }
    }
}

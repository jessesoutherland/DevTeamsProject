using DevTeams_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Komodo_Tests
{
    [TestClass]
    public class Repo_Tests
    {
        private Developer_Repo _repo;
        private Developer _dev;
        private DevTeam_Repo _repo2;
        private DevTeam _team;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new Developer_Repo();
            _dev = new Developer("Jesse", "Southerland", 1234, true);
            _repo2 = new DevTeam_Repo();
            _team = new DevTeam("Warriors", 54321);

            _repo.AddDeveloperToDirectory(_dev);
            _repo2.AddDevTeamToList(_team);
        } 

        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            Developer dev = new Developer();
            dev.IDNumber = 12345;
            Developer_Repo repo = new Developer_Repo();

            repo.AddDeveloperToDirectory(dev);
            Developer devFromDirectory = repo.GetDevByID(12345);

            Assert.IsNotNull(devFromDirectory);
        }

        [TestMethod]
        public void UpdateDevs_ShouldReturnTrue()
        {
            Developer newDev = new Developer ("Jesse", "Sutherland", 12345, false);

            bool updateResult = _repo.UpdateDeveloper(1234, newDev);

            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow (1234, true)]
        [DataRow (123345, false)]
        public void UpdateDevs_ShouldMatchBool(int originalID, bool shouldUpdate)
        {
            Developer newDev = new Developer("Jesse", "Sutherland", 12345, false);

            bool updateResult = _repo.UpdateDeveloper(originalID, newDev);

            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteDev_ShouldReturnTrue()
        {
            bool deleteDev = _repo.DeleteDeveloper(_dev.IDNumber);

            Assert.IsTrue(deleteDev);
        }

        [TestMethod]
        public void AddTeam_ShouldGetNotNull()
        {
            DevTeam newTeam = new DevTeam();
            newTeam.TeamID = 12345;

            DevTeam_Repo newRepo = new DevTeam_Repo();
            newRepo.AddDevTeamToList(newTeam);

            DevTeam devsFromDirectory = newRepo.GetTeamByID(12345);
            Assert.IsNotNull(devsFromDirectory);
        }

        [TestMethod]
        public void UpdateTeam_ShouldGetTrue()
        {
            DevTeam newTeam = new DevTeam("Worriers", 98765);

            bool updateResult = _repo2.UpdateTeam(54321, newTeam);

            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void Delete_Team_ShouldReturnTrue()
        {
            bool deleteDev = _repo2.RemoveDevTeam(_team.TeamID);

            Assert.IsTrue(deleteDev);
        }
    }
}

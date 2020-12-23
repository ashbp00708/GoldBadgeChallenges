using _03_Badges_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _03_Badges_ConsoleApp
{
    [TestClass]
    public class BadgesUnitTest
    {
        private BadgesRepo _repoBadge;
        private Badges _badges;

        [TestInitialize]
        public void BadgesArranged()
        {
            _repoBadge = new BadgesRepo();
            _badges = new Badges(1, "front, back");

            _repoBadge.CreateNewBadge(_badges.BadgeID, _badges);
        }
        [TestMethod]
        public void CreateNewBadge_NotNull()
        {
            Badges badges = new Badges();
            badges.BadgeID = 4;
            BadgesRepo repo = new BadgesRepo();
            repo.CreateNewBadge(_badges.BadgeID, badges);
            Badges badgesFromDictionary = repo.SearchBadgeID(4);
            Assert.IsNotNull(badgesFromDictionary);
        }
        [TestMethod]
        public void UpdateBadgeAccess_ReturnTrue()
        {
            Badges newBadge = new Badges(1, "leftside, back");
            bool updateBadge = _repoBadge.UpdateBadgeAccess(1, newBadge);
            Assert.IsTrue(updateBadge);
        }
        [TestMethod]
        public void DeleteDoorFromBadge_ReturnTrue()
        {
            bool deleteAccess = _repoBadge.DeleteDoorFromBadge(_badges.BadgeID);
            Assert.IsTrue(deleteAccess);
        }
    }
   
   
}

using KClaims_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KClaims_UnitTest
{
    [TestClass]
    public class ClaimsUnitTest
    {
        private ClaimsRepo _claimsRepo;
        private Claims _claims;
        [TestInitialize]
        public void ClaimsArranged()
        {
            _claimsRepo = new ClaimsRepo();
            _claims = new Claims(1, ClaimType.Car, "Rear-ended on Southport and Emerson.", 475.00, "08/10/20", "8/15/20", true);
            _claimsRepo.EnterNewClaim(_claims);
        }
        [TestMethod]
        public void EnterNewClaim_NotNull()
        {
            Claims element = new Claims();
            element.ClaimId = 4;
            ClaimsRepo repo = new ClaimsRepo();
            repo.EnterNewClaim(element);
            Claims getClaimId = repo.GetClaimByID(4);
            Assert.IsNotNull(getClaimId);
        }
        public void TakeCareOfNextClaim_IsTrue()
        {

            bool dequeueNextClaim = _claimsRepo.TakeCareOfNextClaim();
            Assert.IsTrue(dequeueNextClaim);
             
        }
    }
}








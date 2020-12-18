using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace KClaims_ClassLibrary
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class Claims
    {
        public int ClaimId { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public string DateOfIncidentS { get; set; }
        public string DateOfClaimS { get; set; }
        public bool IsValid { get; set; }

        public Claims() { }
        public Claims(int claimId, ClaimType claim, string description, double claimAmount, string dateOfIncidentS, string dateOfClaimS, bool isValid)
        {
            ClaimId = claimId;
            TypeOfClaim = claim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncidentS = dateOfIncidentS;
            DateOfClaimS = dateOfClaimS;
            IsValid = isValid;
        }
    }

}

using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClaims_ClassLibrary
{
    public class ClaimsRepo
    {
        private List<Claims> _claimsList = new List<Claims>();
        private readonly Queue<Claims> _claimsQueue = new Queue<Claims>();
        public void EnterNewClaim(Claims element)
        {
            _claimsQueue.Enqueue(element);
        }
        public List<Claims> ShowAllClaims()
        {
            return _claimsList;
        }
        public void ViewNextInQueue()
        {
            Queue<Claims> _claimsQueue = new Queue<Claims>();

           _claimsQueue.Peek();
        }
        public List<Claims> QueueToListClaims()
        {
            List<Claims> _claimsList = _claimsQueue.ToList();
            foreach (Claims element in _claimsList)
            {
                element.ClaimId.ToString();
                element.TypeOfClaim.ToString();
                element.Description.ToString();
                element.ClaimAmount.ToString();
                element.DateOfIncidentS.ToString();
                element.DateOfClaimS.ToString();
                element.IsValid.ToString();
                return _claimsList;
            }
            return null;
        }
        public Claims GetClaimByID(int claimId)
        {
            foreach(Claims element in _claimsQueue)
            {
                if(element.ClaimId == claimId)
                {
                    return element;
                }
            }
            return null;
        }
        
    }
}

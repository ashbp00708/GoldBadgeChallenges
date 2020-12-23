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
        private Queue<Claims> _claimsQueue = new Queue<Claims>();

        public void EnterNewClaim(Claims element)
        {
            _claimsQueue.Enqueue(element);
        }
        public void ShowAllClaims()
        {
            foreach(Claims element in _claimsQueue)
            {
                Console.WriteLine(element);   
            }
        }
        public void ViewNextInQueue()
        {
           _claimsQueue.Peek();
        }
        public bool TakeCareOfNextClaim()
        {
            Claims nextClaim = _claimsQueue.Peek();
            if (nextClaim != null)
            {
                _claimsQueue.Dequeue();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Claims GetClaimByID(int claimId)
        {
        foreach (Claims element in _claimsQueue)
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

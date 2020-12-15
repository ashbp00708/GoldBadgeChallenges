using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClaims_ClassLibrary
{
    class ClaimsRepo
    {
       
        private Queue<Claims> _claimsElements = new Queue<Claims>();
        public void EnterNewClaim(Claims element)
        {
            _claimsElements.Enqueue(element);
        }
        public Queue<Claims> ViewAllClaims()
        {
            return _claimsElements;
        }
        public void HandleNextClaim() 
        {
            Claims nextClaim = _claimsElements.Peek();
            if(nextClaim.IsValid ==true)
                {
                _claimsElements.Dequeue();

            }
            if(nextClaim.IsValid ==false)
            {

            }
            else
            {
                Console.WriteLine("Please Enter y/n.");
            }
            
        }
        public Claims GetClaimByID(int claimId)
        {
            foreach(Claims element in _claimsElements)
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

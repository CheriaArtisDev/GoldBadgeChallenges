using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Repository
{
    public class ClaimRepo
    {
        protected readonly List<Claim> _claimsDirectory = new List<Claim>();

        public bool AddClaimToDirectory(Claim claim)
        {
            int startingCount = _claimsDirectory.Count;

            _claimsDirectory.Add(claim);

            bool wasAdded = (_claimsDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Claim> GetClaims()
        {
            return _claimsDirectory;
        }

        public Claim GetClaimByNumber(int claimNumberToGet)
        {
            foreach (Claim content in _claimsDirectory)
            {
                if (content.ClaimNumber == claimNumberToGet)
                {
                    return content;
                }
            }
            return null;
        }
        public bool DeleteClaim(Claim existingContent)
        {
            bool result = _claimsDirectory.Remove(existingContent);
            return result;
        }
    }
}

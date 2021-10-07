using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Repository
{
    public class Claim
    {

        public Claim() { }

        public Claim(int claimNumber, string claimType, string description, decimal amount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid) 
        {
            ClaimNumber = claimNumber;
            ClaimType = claimType;
            Description = description;
            Amount = amount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

        public int ClaimNumber { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime  DateOfClaim { get; set; }
        public DateTime DateOfIncident { set; get; }
        public bool IsValid { get; set; }
    }
}

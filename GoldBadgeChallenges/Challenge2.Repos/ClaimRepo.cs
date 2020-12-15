using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.Repos
{
    public class ClaimRepo
    {
        private readonly Queue<Claim> _claimDirectory = new Queue<Claim>();


        // Create
        public void AddClaimToQueue(Claim claim)
        {
            _claimDirectory.Enqueue(claim); //Fields have underscores. Properties don't
        }

        // Read
        public Queue<Claim> GetClaimQueue()
        {
            return _claimDirectory;
        }

        // Update
        public bool UpdateExistingClaim(string originalID, Claim newID)
        {
            //Find
            Claim oldID = GetClaimByID(originalID);

            //Update
            if (oldID != null)
            {
                oldID.ClaimID = newID.ClaimID;
                oldID.ClaimType = newID.ClaimType;
                oldID.Description = newID.Description;
                oldID.ClaimAmount = newID.ClaimAmount;
                oldID.DateOfIncident = newID.DateOfIncident;
                oldID.DateOfClaim = newID.DateOfClaim;
                oldID.IsValid = newID.IsValid;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveClaimFromQueue()
        {

            int initialCount = _claimDirectory.Count;

            _claimDirectory.Dequeue();

            if (initialCount > _claimDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper (Get Meal by ID)
        public Claim GetClaimByID(string iD)
        {
            foreach (Claim claim in _claimDirectory)
            {
                if (claim.ClaimID == iD)
                {
                    return claim;
                }
            }

            return null;
        }

        public Claim GetNextClaim()
        {
            if (_claimDirectory.Count > 0)
            {
                return _claimDirectory.Peek();
            }
            return null;
        }

    }
}

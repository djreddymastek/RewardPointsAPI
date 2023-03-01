using System;
namespace RewardPointsAPI.Models
{
    // Define the data model for a total reward summary
    public class TotalRewardSummary
    {
        public int CustomerId { get; set; }
        public int TotalPoints { get; set; }
    }
}


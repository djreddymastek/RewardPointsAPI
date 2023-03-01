using System;
namespace RewardPointsAPI.Models
{
    // Define the data model for a monthly reward summary
    public class MonthlyRewardSummary
    {
        public int CustomerId { get; set; }
        public int Month { get; set; }
        public int TotalPoints { get; set; }
    }
}


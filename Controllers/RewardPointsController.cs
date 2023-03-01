using RewardPointsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace RewardPointsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RewardPointsController : ControllerBase
    {
        // Define the list of transactions (assumed to be provided by a data source)
        private static List<Transaction> transactions = new List<Transaction>
        {
            new Transaction { CustomerId = 1, Date = new DateTime(2023, 1, 1), Amount = 60.00m },
            new Transaction { CustomerId = 1, Date = new DateTime(2023, 2, 1), Amount = 120.00m },
            new Transaction { CustomerId = 1, Date = new DateTime(2023, 3, 1), Amount = 80.00m },
            new Transaction { CustomerId = 2, Date = new DateTime(2023, 1, 1), Amount = 90.00m },
            new Transaction { CustomerId = 2, Date = new DateTime(2023, 2, 1), Amount = 70.00m },
            new Transaction { CustomerId = 2, Date = new DateTime(2023, 3, 1), Amount = 110.00m },
        };

        /*
         This endpoint calculates the total reward points earned by each customer by grouping the transactions by customer ID and using the LINQ Sum method to calculate the total reward points earned for each customer.
         */
        [HttpGet("~/get")]
        public IEnumerable<TotalRewardSummary> Get()
        {
            // Calculate the total reward points earned by each customer
            var totalRewards = transactions.GroupBy(t => t.CustomerId)
                                            .Select(g => new TotalRewardSummary
                                            {
                                                CustomerId = g.Key,
                                                TotalPoints = g.Sum(t => CalculateRewardPoints(t.Amount))
                                            });
            return totalRewards;
        }

        /*
         This endpoint calculates the reward points earned by each customer per month by grouping the transactions by customer ID and month and using the LINQ Sum method to calculate the total reward points earned for each customer in each month.
         */
        [HttpGet("~/getmonthly")]
        public IEnumerable<MonthlyRewardSummary> GetMonthly()
        {
            // Calculate the reward points earned by each customer per month
            var monthlyRewards = transactions.GroupBy(t => new { t.CustomerId, t.Date.Month })
                                            .Select(g => new MonthlyRewardSummary
                                            {
                                                CustomerId = g.Key.CustomerId,
                                                Month = g.Key.Month,
                                                TotalPoints = g.Sum(t => CalculateRewardPoints(t.Amount))
                                            });
            return monthlyRewards;
        }

        // Helper function to calculate the reward points for a given transaction amount
        /*
         The helper function CalculateRewardPoints takes a decimal amount as input and calculates the reward points earned based on the rules described in the problem statement: for every dollar spent over $50 on the transaction, the customer receives one point; in addition, for every dollar spent over $100, the customer receives another point
         */
        private static int CalculateRewardPoints(decimal amount)
        {
            int points = 0;
            if (amount > 50.00m)
            {
                points += (int)Math.Floor(amount - 50.00m);
            }
            if (amount > 100.00m)
            {
                points += (int)Math.Floor(amount - 100.00m);
            }
            return points;
        }
    }
}
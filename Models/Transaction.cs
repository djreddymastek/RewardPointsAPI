using System;
namespace RewardPointsAPI.Models
{
    // Define the data model for a transaction
    /*
     Data model for a transaction, which has three properties: CustomerId (an integer), Date (a DateTime), and Amount (a decimal)
     */
    public class Transaction
    {
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



//OPEN-CLOSED PRICIPLE
//States that software entities(classes/modules) should
//be open for EXTENSIONS, but closed for modification

//SRP is the prerequisite for OCP
//The advantage is simple testing is required to test individual classes



//Example of class violating OCP
namespace ViolatingOCP
{
    public class Account
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Balance { get; set; }

        //This is violating OCP becouse if in the future
        //it will need to add other subscriptions
        //this method will be modified several times
        public double CalculateInterest(Subscription subscription)
        {
            if (subscription is Subscription.Gold) { return Balance * 0.3; }
            else if (subscription is Subscription.Platinum) { return Balance * 0.5; }
            else return Balance * 0.09;
        }
    }

    public enum Subscription
    {
        Gold,
        Silver,
        Platinum,
        Basic
    }
}


//Example of class violating OCP
namespace FollowingOCP
{
    public class Account
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Balance { get; set; }
    }

    interface IAccount
    {
        double CalculateInterest(Account account);
    }

    //if you want add a new kind of account, you have to add a new extension
    public class GoldAccount : IAccount
    {
        public double CalculateInterest(Account account)
        {
            return account.Balance * 0.3;
        }
    }
    public class PlatinumAccount : IAccount
    {
        public double CalculateInterest(Account account)
        {
            return account.Balance * 0.5;
        }
    }
}
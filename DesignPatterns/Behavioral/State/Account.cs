namespace DesignPatterns.State;

public class Account
{
    public Account(string owner)
    {
        this.Owner = owner;
        this.State = new SilverState(0.0, this);
    }

    public string Owner { get; }

    public double Balance => this.State.Balance;

    public State State { get; set; }

    public void Deposit(double amount)
    {
        this.State.Deposit(amount);
    }

    public void Withdraw(double amount)
    {
        this.State.Withdraw(amount);
    }

    public void PayInterest()
    {
        this.State.PayInterest();
    }
}
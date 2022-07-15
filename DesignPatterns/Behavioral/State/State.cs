namespace DesignPatterns.State;

public abstract class State
{
    protected State(Account account)
    {
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
    }

    protected double Interest { get; set; }

    protected double LowerLimit { get; set; }

    protected double UpperLimit { get; set; }

    public Account Account { get; protected init; }

    public double Balance { get; protected set; }

    public abstract void Deposit(double amount);

    public abstract void Withdraw(double amount);

    public abstract void PayInterest();
}
namespace DesignPatterns.Behavioral.State;

public class GoldState : State
{
    // Overloaded constructors
    public GoldState(State state)
        : this(state.Balance, state.Account)
    {
    }

    private GoldState(double balance, Account account)
        : base(account)
    {
        this.Balance = balance;
        this.Account = account;
        this.Initialize();
    }

    private void Initialize()
    {
        // Should come from a database
        this.Interest = 0.05;
        this.LowerLimit = 1000.0;
        this.UpperLimit = 10000000.0;
    }

    public override void Deposit(double amount)
    {
        this.Balance += amount;
        this.StateChangeCheck();
    }

    public override void Withdraw(double amount)
    {
        this.Balance -= amount;
        this.StateChangeCheck();
    }

    public override void PayInterest()
    {
        this.Balance += this.Interest * this.Balance;
        this.StateChangeCheck();
    }

    private void StateChangeCheck()
    {
        if (this.Balance < 0.0)
            this.Account.State = new RedState(this);
        else if (this.Balance < this.LowerLimit)
            this.Account.State = new SilverState(this);
    }
}
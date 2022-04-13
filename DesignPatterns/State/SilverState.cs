namespace DesignPatterns.State;

public class SilverState : State
{
    // Overloaded constructors
    public SilverState(State state) :
        this(state.Balance, state.Account)
    {
    }

    public SilverState(double balance, Account account)
        : base(account)
    {
        this.Balance = balance;
        this.Account = account;
        this.Initialize();
    }

    private void Initialize()
    {
        this.Interest = 0.0;
        this.LowerLimit = 0.0;
        this.UpperLimit = 1000.0;
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
        if (this.Balance < this.LowerLimit)
        {
            this.Account.State = new RedState(this);
        }
        else if (this.Balance > this.UpperLimit)
        {
            this.Account.State = new GoldState(this);
        }
    }
}
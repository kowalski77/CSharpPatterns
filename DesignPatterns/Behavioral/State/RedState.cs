namespace DesignPatterns.State;

public class RedState : State
{
    private double serviceFee;

    // Constructor
    public RedState(State state) : base(state.Account)
    {
        this.Balance = state.Balance;
        this.Initialize();
    }

    private void Initialize()
    {
        this.Interest = 0.0;
        this.LowerLimit = -100.0;
        this.UpperLimit = 0.0;
        this.serviceFee = 15.00;
    }

    public override void Deposit(double amount)
    {
        this.Balance += amount;
        this.StateChangeCheck();
    }

    public override void Withdraw(double amount)
    {
        this.Balance = amount - this.serviceFee;
    }

    public override void PayInterest()
    {
        // No interest is paid
    }

    private void StateChangeCheck()
    {
        if (this.Balance > this.UpperLimit)
        {
            this.Account.State = new SilverState(this);
        }
    }
}
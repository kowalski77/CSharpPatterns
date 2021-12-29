namespace ChainOfResponsibilityAlternative;

public class NoMultipleHandler : IHandler<Number>
{
    public void Handle(Number request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (!request.IsDivisibleBy(3) && !request.IsDivisibleBy(5))
        {
            Console.WriteLine($"The Number: {request.Value} has no defined multiples");
        }
    }
}
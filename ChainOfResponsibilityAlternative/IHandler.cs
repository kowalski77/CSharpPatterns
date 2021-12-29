namespace ChainOfResponsibilityAlternative;

public interface IHandler<in T> where T : class
{
    void Handle(T request);
}
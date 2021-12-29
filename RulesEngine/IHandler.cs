namespace RulesEngine;

public interface IHandler<in T> where T : class
{
    void Handle(T request);
}
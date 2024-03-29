﻿namespace DesignPatterns.Behavioral.RulesEngine;

public interface IHandler<in T> where T : class
{
    string Handle(T request);
}
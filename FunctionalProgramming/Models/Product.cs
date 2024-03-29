﻿using FunctionalProgramming.Support;

namespace FunctionalProgramming.Models;

public class Product
{
    public Product(Guid id, string name, Money cost)
    {
        this.Id = id;
        this.Name = name.NonEmpty(nameof(name));
        this.Cost = cost;
    }

    public Guid Id { get; }

    public string Name { get; }

    public Money Cost { get; }

    public static IComparer<Product> CostComparer =>
        Comparer<Product>.Create((a, b) => a.Cost.CompareTo(b.Cost));

    public override string ToString() => $"Id: {this.Id} - Name: {this.Name} - Cost: {this.Cost.Amount}";
}

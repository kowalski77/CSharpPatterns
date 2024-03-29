﻿namespace FunctionalProgramming.Constructors.SequenceFactoryMethods;

public class Product
{
    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public string Name { get; }

    public decimal Price { get; }

    public int Stock { get; } = 5;

    public bool IsFeatured { get; set; }
}

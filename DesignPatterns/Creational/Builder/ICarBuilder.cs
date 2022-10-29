﻿namespace DesignPatterns.Creational.Builder;

public interface ICarBuilder
{
    ICarBuilder SetMake(string make);

    ICarBuilder SetColor(Color color);

    ICarBuilder SetManufactureDate(DateTime manufactureDate);

    Car Build();
}

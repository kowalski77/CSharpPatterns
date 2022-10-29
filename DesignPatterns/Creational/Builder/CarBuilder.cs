namespace DesignPatterns.Creational.Builder;

public class CarBuilder : ICarBuilder
{
    private readonly Car car = new();

    public ICarBuilder SetColor(Color color)
    {
        this.car.Color = color;
        return this;
    }

    public ICarBuilder SetMake(string make)
    {
        this.car.Make = make;
        return this;
    }

    public ICarBuilder SetManufactureDate(DateTime manufactureDate)
    {
        this.car.ManufactureDate = manufactureDate;
        return this;
    }

    public Car Build() => this.car;
}

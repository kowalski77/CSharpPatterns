namespace DesignPatterns.Creational.Builder;

public class Demo
{
    public void Run()
    {
        var carBuilder = new CarBuilder();
        BuildVwSantana1995(carBuilder);

        var car = carBuilder.Build();
    }
    
    private void BuildVwSantana1995(ICarBuilder carBuilder)
    {
        carBuilder
            .SetMake("VW Santana")
            .SetColor(Color.White)
            .SetManufactureDate(new DateTime(1995, 1, 1));
    }
}

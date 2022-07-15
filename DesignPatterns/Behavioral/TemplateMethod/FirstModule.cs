namespace DesignPatterns.TemplateMethod;

public class FirstModule : ModuleBase<FirstStuff>
{
    protected override void DoFirstThing()
    {
        this.Stuff.Item = "First thing done";
    }

    protected override void DoSecondThing()
    {
        this.Stuff.Item += "Second thing done";
    }
}
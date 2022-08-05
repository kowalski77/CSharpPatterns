using System.Runtime.CompilerServices;

namespace CSharpPatterns.Tests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        //VerifySourceGenerators.Enable();
        VerifyAspNetCore.Enable();
    }
}
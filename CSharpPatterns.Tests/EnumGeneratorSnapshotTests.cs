using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace CSharpPatterns.Tests;

[UsesVerify] // 👈 Adds hooks for Verify into XUnit
public class EnumGeneratorSnapshotTests
{
    [Fact]
    public Task GeneratesEnumExtensionsCorrectly()
    {
        // The source code to test
        var source = @"
using SourceGenerators.EnumGenerators;

[EnumExtensions]
public enum Colour
{
    Red = 0,
    Blue = 1,
}";

        // Pass the source code to our helper and snapshot test the output
        return TestHelper.Verify(source);
    }
}
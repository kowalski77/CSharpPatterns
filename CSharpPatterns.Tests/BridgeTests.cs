using DesignPatterns.Structural.Bridge;
using FluentAssertions;
using Xunit;

namespace CSharpPatterns.Tests;

public class BridgeTests
{
    [Fact]
    public void Simple_invoice_header_is_created_with_the_delevery_note_parser()
    {
        // Arrange
        var simpleInvoiceBuilder = new SimpleInvoiceBuilder(new DeliverNoteParser());

        // Act
        var header = simpleInvoiceBuilder.BuildHeader();

        // Assert
        header.Should().Be("Delivery note header: Header { Data = Invoice }");
    }
}

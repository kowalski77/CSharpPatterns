using FluentAssertions;
using Playground.Invariance;

namespace CSharpPatterns.Tests;

public class InvarianceTests
{
    [Fact]
    public void Arrays_covariance_readonly_operation_is_ok()
    {
        // Arrange
        static IEnumerable<string> PrintNames(Person[] people)
        {
            foreach (var item in people)
            {
                yield return item.Name;
            }
        };

        var people = new[] { new Person("John"), new Student("Mary"), new Teacher("Mike") };

        // Act
        var result = PrintNames(people).ToList();

        // Assert
        result.Count.Should().Be(3);
    }

    [Fact]
    public void Arrays_covariance_not_readonly_operation_fails()
    {
        // Arrange
        static void UpdateFirst(Person[] people)
        {
            people[0] = new Teacher("Sarah");
        }

        var student = new[] { new Student("John") };

        // Act
        var action = () => UpdateFirst(student);

        // Assert
        action.Should().Throw<ArrayTypeMismatchException>()
            .And.Message.Should().Contain("Attempted to access an element as a type incompatible with the array");
    }

    [Fact]
    public void Covariance_interface_is_safe_for_derived_types_as_out_parameter()
    {
        // Arrange
        var students = new[] { new Student("John"), new Student("Mary"), new Student("Mike") };
        IPersonReadOnlyCollection<Person> collection = new PersonReadOnlyCollection<Student>(students);

        // Act
        var result = collection.GetFirstElement();

        // Assert
        result.Should().BeOfType<Student>();
        result.Name.Should().Be("John");
    }

    [Fact]
    public void Contravariance_interface_is_safe_for_base_types_as_in_parameters()
    {
        // Arrange
        static int Compare(IMyComparer<Student> comparer)
        {
            var s1 = new Student("John");
            var s2 = new Student("Peter");
            return comparer.Compare(s1, s2);
        }

        // Act
        IMyComparer<Person> personComparer = new PersonComparer();
        var result = Compare(personComparer);

        // Assert
        result.Should().Be(-6);
    }
}

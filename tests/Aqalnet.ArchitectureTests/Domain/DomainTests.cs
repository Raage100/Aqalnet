using System.Reflection;
using Aqalnet.ArchitectureTests.Infrastructure;
using Aqalnet.Domain.Abstractions;
using FluentAssertions;
using NetArchTest.Rules;

namespace Aqalnet.ArchitectureTests.Domain;

public class DomainTests : BaseTest
{
    [Fact]
    public void DomainEvent_Should_beSealed()
    {
        var result = Types
            .InAssembly(DomainAssembly)
            .That()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .BeSealed()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainEvent_ShouldHave_DomainEventPostFix()
    {
        var result = Types
            .InAssembly(DomainAssembly)
            .That()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .HaveNameEndingWith("DomainEvent")
            .GetResult();
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Entities_ShouldHave_PrivateParameterlessContructur()
    {
        IEnumerable<Type> entityTypes = Types
            .InAssembly(DomainAssembly)
            .That()
            .Inherit(typeof(Entity))
            .GetTypes();
        var failingTypes = new List<Type>();
        foreach (var entityType in entityTypes)
        {
            var constructors = entityType.GetConstructors(
                BindingFlags.NonPublic | BindingFlags.Instance
            );
            if (constructors.Any(c => c.IsPrivate && c.GetParameters().Length == 0))
            {
                failingTypes.Add(entityType);
            }
        }
        failingTypes.Should().BeEmpty();
    }
}

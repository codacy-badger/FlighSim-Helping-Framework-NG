// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using FlightSimStandardLibraryNG.Core.Hashing;
using FluentAssertions;
using Xunit;

#endregion

namespace FlightSimStandardLibraryNG.Core.UnitTests.Tests.Hashing
{
    [Trait("Category", "Unit tests")]
    public class CustomHashTests
    {
        [Fact]
        public void AddToHashNumber_ShouldGiveNewHash_SameNumberEachTime()
        {
            //Act
            int firstResult = CustomHash
                .GetInitialHashNumber()
                .AddToHashNumber("Test".GetHashCode())
                .AddToHashNumber("Test2".GetHashCode());

            int secondResult = CustomHash
                .GetInitialHashNumber()
                .AddToHashNumber("Test".GetHashCode())
                .AddToHashNumber("Test2".GetHashCode());

            //Assert
            firstResult.Should().Be(secondResult);
        }

        [Fact]
        public void GetInitialHashNumber_ShouldReturnNonzeroNumber_SameNumberEachTime()
        {
            //Act
            int firstResult = CustomHash.GetInitialHashNumber();
            int secondResult = CustomHash.GetInitialHashNumber();

            //Assert
            firstResult.Should().NotBe(0);
            firstResult.Should().Be(secondResult);
        }
    }
}
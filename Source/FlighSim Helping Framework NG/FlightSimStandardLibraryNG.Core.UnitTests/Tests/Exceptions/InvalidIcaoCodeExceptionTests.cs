// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using FlightSimStandardLibraryNG.Core.Exceptions;
using FluentAssertions;
using TestingHelper.Strings;
using Xunit;

#endregion

namespace FlightSimStandardLibraryNG.Core.UnitTests.Tests.Exceptions
{
    [Trait("Category", "Unit tests")]
    public class InvalidIcaoCodeExceptionTests
    {
        [Theory]
        [MemberData(nameof(Strings.ValidStrings), MemberType = typeof(Strings))]
        public void Constuctor_WithValidMessage_ShouldConstruct(string message)
        {
            //Act
            InvalidIcaoCodeException ex = new InvalidIcaoCodeException(message);

            //Assert
            ex.Message.Should().Be(message);
        }

        [Theory]
        [MemberData(nameof(Strings.ValidStrings), MemberType = typeof(Strings))]
        public void
            Constuctor_WithValidMessageAndNullInnerException_ShouldConstructWithDefaultMessage(
                string message)
        {
            //Act
            InvalidIcaoCodeException ex =
                new InvalidIcaoCodeException(message, null);

            //Assert
            ex.InnerException.Should().BeNull();
        }

        [Fact]
        public void Constuctor_WithNullMessage_ShouldConstructWithDefaultMessage()
        {
            //Act
            InvalidIcaoCodeException ex = new InvalidIcaoCodeException(null);

            //Assert
            ex.Message.Should().NotBeNull();
        }

        [Fact]
        public void
            Constuctor_WithValidMessageAndInnerException_ShouldConstructWithDefaultMessage()
        {
            //Act
            InvalidIcaoCodeException ex =
                new InvalidIcaoCodeException("Message", new InvalidIcaoCodeException(nameof(ex)));

            //Assert
            nameof(ex).Should().Be(ex.InnerException.Message);
        }

        [Fact]
        public void DefaultConstuctor_ShouldConstruct()
        {
            //Act
            InvalidIcaoCodeException ex = new InvalidIcaoCodeException();

            //Assert
            ex.Should().NotBeNull();
        }
    }
}
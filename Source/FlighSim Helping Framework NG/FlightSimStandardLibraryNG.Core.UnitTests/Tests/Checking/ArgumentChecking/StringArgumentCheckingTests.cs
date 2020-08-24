// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using FlightSimStandardLibraryNG.Core.Checking.ArgumentChecking;
using FluentAssertions;
using TestingHelper.Strings;
using Xunit;

#endregion

namespace FlightSimStandardLibraryNG.Core.UnitTests.Tests.Checking.ArgumentChecking
{
    [Trait("Category", "Unit tests")]
    public class StringArgumentCheckingTests
    {
        [Theory]
        [MemberData(nameof(Strings.InvalidStrings), MemberType = typeof(Strings))]
        public void IsStringValid_WithInvalidStrings_ShouldWork(string toCheck)
        {
            //Act
            bool result = StringArgumentChecking.IsStringValid(toCheck);

            //Assert
            result.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(Strings.ValidStrings), MemberType = typeof(Strings))]
        public void IsStringValid_WithValidStrings_ShouldWork(string toCheck)
        {
            //Act
            bool result = StringArgumentChecking.IsStringValid(toCheck);

            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(Strings.CollectionsWithValidStrings), MemberType = typeof(Strings))]
        public void ThrowExceptionIfContainsInvalidString_WithValidStrings_ShouldNotThrow_ArgumentException(
            string[] toCheck)
        {
            //Act
            Action act = () =>
                StringArgumentChecking.ThrowExceptionIfNullOrContainsInvalidString(toCheck, nameof(toCheck));

            //Assert
            act.Should().NotThrow();
        }

        [Theory]
        [MemberData(nameof(Strings.CollectionsWithMixedValidAndInvalidStrings), MemberType = typeof(Strings))]
        public void
            ThrowExceptionIfNullOrContainsInvalidString_WithMixedInvalidAndValidStrings_ShouldThrow_ArgumentException(
                string[] toCheck)
        {
            //Act
            Action act = () =>
                StringArgumentChecking.ThrowExceptionIfNullOrContainsInvalidString(toCheck, nameof(toCheck));

            //Assert
            act.Should().ThrowExactly<ArgumentException>().Where(e => e.Message.Contains(nameof(toCheck)));
        }

        [Theory]
        [InlineData(null)]
        public void ThrowExceptionIfNullOrContainsInvalidString_WithNullArgument_ShouldThrow_ArgumentNullException(
            string[] toCheck)
        {
            //Act
            Action act = () =>
                StringArgumentChecking.ThrowExceptionIfNullOrContainsInvalidString(toCheck, nameof(toCheck));

            //Assert
            act.Should().ThrowExactly<ArgumentNullException>().Where(e => e.Message.Contains(nameof(toCheck)));
        }

        [Theory]
        [MemberData(nameof(Strings.InvalidStrings), MemberType = typeof(Strings))]
        public void ThrowExceptionIfStringIsInvalid_WithInvalidStrings_ShouldThrow_ArgumentException(string toCheck)
        {
            //Act
            Action act = () => StringArgumentChecking.ThrowExceptionIfStringIsInvalid(toCheck, nameof(toCheck));

            //Assert
            act.Should().ThrowExactly<ArgumentException>().Where(e => e.Message.Contains(nameof(toCheck)));
        }

        [Theory]
        [MemberData(nameof(Strings.ValidStrings), MemberType = typeof(Strings))]
        public void ThrowExceptionIfStringIsInvalid_WithValidStrings_ShouldNotThrow_ArgumentException(string toCheck)
        {
            //Act
            Action act = () => StringArgumentChecking.ThrowExceptionIfStringIsInvalid(toCheck, nameof(toCheck));

            //Assert
            act.Should().NotThrow();
        }
    }
}
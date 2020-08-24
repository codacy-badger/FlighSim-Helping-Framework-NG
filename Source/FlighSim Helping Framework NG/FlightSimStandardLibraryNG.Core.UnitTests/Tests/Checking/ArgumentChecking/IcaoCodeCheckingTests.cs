// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using FlightSimStandardLibraryNG.Core.Checking.ArgumentChecking;
using FlightSimStandardLibraryNG.Core.Exceptions;
using FluentAssertions;
using TestingHelper.IcaoCodes;
using Xunit;

#endregion

namespace FlightSimStandardLibraryNG.Core.UnitTests.Tests.Checking.ArgumentChecking
{
    [Trait("Category", "Unit tests")]
    public class IcaoCodeCheckingTests
    {
        [Theory]
        [MemberData(nameof(IcaoCodes.ValidStringIcaoCodesCollection), MemberType = typeof(IcaoCodes))]
        public void IsIcaoCodeStringValid_WithValidCodes_ShouldWork(string icaoCode)
        {
            //Act
            bool result = IcaoCodeChecking.IsIcaoCodeStringValid(icaoCode);

            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(IcaoCodes.InvalidStringIcaoCodesCollection), MemberType = typeof(IcaoCodes))]
        public void IsIcaoCodeStringValid_WithInvalidCodes_ShouldWork(string icaoCode)
        {
            //Act
            bool result = IcaoCodeChecking.IsIcaoCodeStringValid(icaoCode);

            //Assert
            result.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(IcaoCodes.InvalidStringIcaoCodesCollection), MemberType = typeof(IcaoCodes))]
        public void ThrowExceptionIfIcaoCodeIsInvalid_WithInvalidCodes_ShouldThrow_InvalidIcaoCodeException(
            string icaoCode)
        {
            //Act
            Action act = () => IcaoCodeChecking.ThrowExceptionIfIcaoCodeIsInvalid(icaoCode);

            //Assert
            act.Should().ThrowExactly<InvalidIcaoCodeException>();
        }

        [Theory]
        [MemberData(nameof(IcaoCodes.ValidStringIcaoCodesCollection), MemberType = typeof(IcaoCodes))]
        public void ThrowExceptionIfIcaoCodeIsInvalid_WithValidCodes_ShouldNotThrow_InvalidIcaoCodeException(
            string icaoCode)
        {
            //Act
            Action act = () => IcaoCodeChecking.ThrowExceptionIfIcaoCodeIsInvalid(icaoCode);

            //Assert
            act.Should().NotThrow();
        }

        [Theory]
        [MemberData(nameof(IcaoCodes.CollectionsWithMixedValidAndInvalidStringIcaoCodes),
            MemberType = typeof(IcaoCodes))]
        public void
            ThrowExceptionIfContainsInvalidIcaoCode_WithMixedValidAndInvalidCodes_ShouldThrow_InvalidIcaoCodeException(
                string[] icaoCodes)
        {
            //Act
            Action act = () => IcaoCodeChecking.ThrowExceptionIfContainsInvalidIcaoCode(icaoCodes);

            //Assert
            act.Should().ThrowExactly<InvalidIcaoCodeException>();
        }

        [Theory]
        [MemberData(nameof(IcaoCodes.CollectionsWithValidStringIcaoCodes), MemberType = typeof(IcaoCodes))]
        public void ThrowExceptionIfContainsInvalidIcaoCode_WithValidCodes_ShouldNotThrow_InvalidIcaoCodeException(
            string[] icaoCodes)
        {
            //Act
            Action act = () => IcaoCodeChecking.ThrowExceptionIfContainsInvalidIcaoCode(icaoCodes);

            //Assert
            act.Should().NotThrow();
        }

        [Theory]
        [MemberData(nameof(IcaoCodes.CollectionsWithInvalidStringIcaoCodes), MemberType = typeof(IcaoCodes))]
        public void
            ThrowExceptionIfContainsInvalidIcaoCode_WithInvalidCodes_ShouldThrow_InvalidIcaoCodeException(
                string[] icaoCodes)
        {
            //Act
            Action act = () => IcaoCodeChecking.ThrowExceptionIfContainsInvalidIcaoCode(icaoCodes);

            //Assert
            act.Should().ThrowExactly<InvalidIcaoCodeException>();
        }

        [Fact]
        public void
            ThrowExceptionIfContainsInvalidIcaoCode_WithNullCollection_ShouldThrow_ArgumentNullException()
        {
            //Act
            // ReSharper disable once AssignNullToNotNullAttribute, because it is a test case
            Action act = () => IcaoCodeChecking.ThrowExceptionIfContainsInvalidIcaoCode(null);

            //Assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}
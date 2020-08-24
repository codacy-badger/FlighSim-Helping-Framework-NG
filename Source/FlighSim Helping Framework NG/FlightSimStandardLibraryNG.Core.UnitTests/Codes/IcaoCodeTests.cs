// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using FlightSimStandardLibraryNG.Core.Codes;
using FlightSimStandardLibraryNG.Core.Exceptions;
using FluentAssertions;
using TestingHelper.IcaoCodes;
using Xunit;

#endregion

namespace FlightSimStandardLibraryNG.Core.UnitTests.Tests.Codes
{
    [Trait("Category", "Unit tests")]
    public class IcaoCodeTests
    {
        [Theory]
        [MemberData(nameof(IcaoCodes.InvalidStringIcaoCodesCollection), MemberType = typeof(IcaoCodes))]
        public void Constructor_WithInvalidParameters_ShouldThrow_InvalidIcaoCodeException(string icaoCodeString)
        {
            //Act
            Action act = () => new IcaoCode(icaoCodeString);

            //Assert
            act.Should().ThrowExactly<InvalidIcaoCodeException>();
        }

        [Theory]
        [MemberData(nameof(IcaoCodes.ValidStringIcaoCodesCollection), MemberType = typeof(IcaoCodes))]
        public void Constructor_WithValidParameters_ShouldCounstruct(string icaoCodeString)
        {
            //Act
            IcaoCode icaoCode = new IcaoCode(icaoCodeString);

            //Assert
            icaoCode.Code.Should().Be(icaoCodeString);
        }

        [Theory]
        [MemberData(nameof(IcaoCodes.ValidStringIcaoCodesCollection), MemberType = typeof(IcaoCodes))]
        public void Equals_WithEqualObjects_ShouldWorkAsExpected(string icaoCodeString)
        {
            //Act
            IcaoCode icaoCode1 = new IcaoCode(icaoCodeString);
            IcaoCode icaoCode2 = new IcaoCode(icaoCodeString);

            //Assert
            icaoCode1.Should().Be(icaoCode2);
        }

        [Theory]
        [MemberData(nameof(IcaoCodes.ValidStringIcaoCodesCollection), MemberType = typeof(IcaoCodes))]
        public void Equals_WithOneNullObject_ShouldWorkAsExpected(string icaoCodeString)
        {
            //Act
            IcaoCode icaoCode1 = new IcaoCode(icaoCodeString);
            IcaoCode icaoCode2 = null;

            bool result = icaoCode1.Equals(icaoCode2);

            result.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(IcaoCodes.ValidStringIcaoCodesCollection), MemberType = typeof(IcaoCodes))]
        public void GetHashCode_WithEqualObjects_ShouldWorkAsExpected(string icaoCodeString)
        {
            //Act
            IcaoCode icaoCode1 = new IcaoCode(icaoCodeString);
            IcaoCode icaoCode2 = new IcaoCode(icaoCodeString);

            int icaoCode1HashCode = icaoCode1.GetHashCode();
            int icaoCode2HashCode = icaoCode2.GetHashCode();

            //Assert
            icaoCode1HashCode.Should().Be(icaoCode2HashCode);
        }

        [Theory]
        [MemberData(nameof(IcaoCodes.ValidStringIcaoCodesCollection), MemberType = typeof(IcaoCodes))]
        public void ToString_ShouldWorkAsExpected(string icaoCodeString)
        {
            //Act
            IcaoCode icaoCode1 = new IcaoCode(icaoCodeString);

            //Assert
            icaoCode1.ToString().Should().Contain(icaoCodeString);
        }
    }
}
// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using FlightSimStandardLibraryNG.Core.Checking.ArgumentChecking;
using FluentAssertions;
using Xunit;

#endregion

namespace FlightSimStandardLibraryNG.Core.UnitTests.Tests.Checking.ArgumentChecking
{
    [Trait("Category", "Unit tests")]
    public class NullCheckingTests
    {
        [Fact]
        public void ThrowExceptionIfNull_WithGoodArguments_ShouldNotThrow_ArgumentNullException()
        {
            //Act
            Action act = () => NullChecking.ThrowExceptionIfNull(new object(), "Something");

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void ThrowExceptionIfNull_WithNullArguments_ShouldThrow_ArgumentNullException()
        {
            //Act
            Action act = () => NullChecking.ThrowExceptionIfNull(null, "Something");

            //Assert
            act.Should().ThrowExactly<ArgumentNullException>().Where(e => e.Message.Contains("Something"));
        }

        [Fact]
        public void ThrowExceptionIfNullOrContainsNull_WithGoodArguments_ShouldNotThrow_ArgumentNullException()
        {
            //Act
            Action act = () =>
                NullChecking.ThrowExceptionIfNullOrContainsNull(new List<object> {new object(), new object()},
                    "Something");

            //Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void ThrowExceptionIfNullOrContainsNull_WithNullArguments_ShouldNotThrow_ArgumentNullException()
        {
            //Act
            Action act = () =>
                NullChecking.ThrowExceptionIfNullOrContainsNull(new List<object> {new object(), null},
                    "Something interesting");

            //Assert
            act.Should().ThrowExactly<ArgumentNullException>().Where(e => e.Message.Contains("Something interesting"));
        }
    }
}
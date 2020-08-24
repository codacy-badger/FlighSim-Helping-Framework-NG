// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using FlightSimStandardLibraryNG.Core.Checking.ArgumentChecking;
using FluentAssertions;
using TestingHelper.Downloader;
using Xunit;

#endregion

namespace FlightSimStandardLibraryNG.Core.UnitTests.Tests.Checking.ArgumentChecking
{
    [Trait("Category", "Unit tests")]
    public class UrlCheckingTests
    {
        [Theory]
        [MemberData(nameof(Urls.InvalidStringUrls), MemberType = typeof(Urls))]
        public void IsUrlValid_WithInvalidUrls_ShouldWork(string urlToCheck)
        {
            //Act
            bool result = UrlChecking.IsUrlValid(urlToCheck);

            //Assert
            result.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(Urls.ValidStringUrls), MemberType = typeof(Urls))]
        public void IsUrlValid_WithValidUrls_ShouldWork(string urlToCheck)
        {
            //Act
            bool result = UrlChecking.IsUrlValid(urlToCheck);

            //Assert
            result.Should().BeTrue();
        }
    }
}
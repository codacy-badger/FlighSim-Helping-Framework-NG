// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;
using System.Linq;

#endregion

namespace TestingHelper.Downloader
{
    public static class Urls
    {
        private static readonly List<string> invalidUrls = new List<string>
        {
            "127.0.0.1",
            "www.example.com",
            "example.com"
        };

        private static readonly List<string> validUrls = new List<string>
        {
            "http://www.example.com",
            "https://www.example.com",

            "http://example1.example.com",
            "https://example1.example.com",

            "http://www.example.com/page",
            "https://www.example.com/page",

            "http://www.example.com/page?id=1&product=2",
            "https://www.example.com/page?id=1&product=2",

            "http://www.example.com/page#start",
            "https://www.example.com/page#start",

            "http://www.example.com:8080",
            "https://www.example.com:8080",

            "http://127.0.0.1",
            "https://127.0.0.1",

            "ftp://127.0.0.1"
        };

        public static IEnumerable<object[]> InvalidStringUrls =>
            CollectionFormers.CollectionFormers.GetXunitMemberDataCollectionFromNormalCollection(
                invalidUrls.ToList<object>());

        public static IEnumerable<object[]> ValidStringUrls =>
            CollectionFormers.CollectionFormers.GetXunitMemberDataCollectionFromNormalCollection(
                validUrls.ToList<object>());
    }
}
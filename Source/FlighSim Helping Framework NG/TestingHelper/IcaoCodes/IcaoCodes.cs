// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;
using System.Linq;
using TestingHelper.Mixers;

#endregion

namespace TestingHelper.IcaoCodes
{
    public static class IcaoCodes
    {
        private static readonly List<string> invalidStringIcaoCodes = new List<string>
        {
            null,
            "",
            " ",
            "ksfo",
            "ксфо", // Russian letters
            "UuEe",
            "UUEЕ", // Russian letter "Е"
            "UUDDA",
            "OMDDB",
            "OM3D",
            "1234",
            "OMD_",
            " UUEE",
            "UUEE ",
            "UUEE#",
            "UUEE(",
            "UU#4"
        };

        private static readonly List<string> validStringIcaoCodes = new List<string>
        {
            "UUEE",
            "UUDD",
            "KLAX",
            "KSFO",
            "MUHA"
        };

        public static IEnumerable<object[]> CollectionsWithInvalidStringIcaoCodes =>
            CollectionFormers.CollectionFormers
                .GetXunitMemberDataCollectionWithIncrementalNumberOfObjectsFromNormalCollection(
                    invalidStringIcaoCodes.ToList<object>());

        public static IEnumerable<object[]> CollectionsWithMixedValidAndInvalidStringIcaoCodes =>
            CollectionsMixer.GetMixupOfTwoCollectionsInTheFormatOfXunitMemberData(
                validStringIcaoCodes.ToList<object>(),
                invalidStringIcaoCodes.ToList<object>());

        public static IEnumerable<object[]> CollectionsWithValidStringIcaoCodes =>
            CollectionFormers.CollectionFormers
                .GetXunitMemberDataCollectionWithIncrementalNumberOfObjectsFromNormalCollection(
                    validStringIcaoCodes.ToList<object>());

        public static IEnumerable<object[]> InvalidStringIcaoCodesCollection =>
            CollectionFormers.CollectionFormers.GetXunitMemberDataCollectionFromNormalCollection(
                invalidStringIcaoCodes.ToList<object>());

        public static IEnumerable<object[]> ValidStringIcaoCodesCollection =>
            CollectionFormers.CollectionFormers.GetXunitMemberDataCollectionFromNormalCollection(
                validStringIcaoCodes.ToList<object>());
    }
}
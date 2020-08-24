// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;
using System.Linq;
using TestingHelper.Mixers;

#endregion

namespace TestingHelper.Strings
{
    public static class Strings
    {
        private static readonly List<string> invalidStrings = new List<string>
        {
            "",
            " ",
            "   ",
            null
        };

        private static readonly List<string> validStrings = new List<string>
        {
            "String",
            "Valid строка",
            "Еще 1 действительная строка (123456789!;)",
            "Ё!№;%:?*()_+)",
            "1 2 3 4 5 _ 6 _ 7 _ 8 _ 9 _ 101",
            "1234567890-=qwertyuiop[]\asdfghjkl;'zxcvbnm,./~!@#$%^&*()_+'",
            "йцукенгшщзхъфывапролджэячсмитьбю.",
            "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ.'",
            "qwertyuiop[]asdfghjkl;'zxcvbnm,./'",
            "QWERTYUIOP[]ASDFGHJKL;'ZXCVBNM,./'",
            "QWERTYUIOP[]ASDFGHJKL;'ZXCVBNM,./iiuoiuh5jthbk9084098650789347q34t;l'"
        };

        public static IEnumerable<object[]> CollectionsWithMixedValidAndInvalidStrings =>
            CollectionsMixer.GetMixupOfTwoCollectionsInTheFormatOfXunitMemberData(
                validStrings.ToList<object>(), invalidStrings.ToList<object>());

        public static IEnumerable<object[]> CollectionsWithValidStrings =>
            CollectionFormers.CollectionFormers
                .GetXunitMemberDataCollectionWithIncrementalNumberOfObjectsFromNormalCollection(
                    validStrings.ToList<object>());

        public static IEnumerable<object[]> InvalidStrings =>
            CollectionFormers.CollectionFormers.GetXunitMemberDataCollectionFromNormalCollection(
                invalidStrings.ToList<object>());

        public static IEnumerable<object[]> ValidStrings =>
            CollectionFormers.CollectionFormers.GetXunitMemberDataCollectionFromNormalCollection(
                validStrings.ToList<object>());
    }
}
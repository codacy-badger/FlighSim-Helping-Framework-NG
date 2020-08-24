// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;

#endregion

namespace TestingHelper.Mixers
{
    /// <summary>
    ///     Static class for mixing collections (for further testing assistance)
    /// </summary>
    public static class CollectionsMixer
    {
        public static IEnumerable<object[]> GetMixupOfTwoCollectionsInTheFormatOfXunitMemberData(
            List<object> firstCollection, List<object> secondCollection)
        {
            List<object[]> toReturn = new List<object[]>();
            foreach (object secondCollectionItem in secondCollection)
            {
                List<object> local = new List<object>();
                int c_i = 0;
                foreach (object firstCollectionItem in firstCollection)
                {
                    local.AddRange(firstCollection);
                    local[c_i] = secondCollectionItem;
                    toReturn.Add(new[] {local});
                    local = new List<object>();
                    c_i++;
                }
            }

            return toReturn;
        }
    }
}
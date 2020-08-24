// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;

#endregion

namespace TestingHelper.CollectionFormers
{
    public static class CollectionFormers
    {
        public static IEnumerable<object[]> GetXunitMemberDataCollectionFromNormalCollection(
            List<object> normalCollection)
        {
            List<object[]> toReturn = new List<object[]>();

            foreach (var item in normalCollection)
            {
                toReturn.Add(new[] {item});
            }

            return toReturn;
        }

        public static IEnumerable<object[]>
            GetXunitMemberDataCollectionWithIncrementalNumberOfObjectsFromNormalCollection(
                List<object> normalCollection)
        {
            List<object[]> toReturn = new List<object[]>();
            int border = 1;
            foreach (string iteam in normalCollection)
            {
                List<object> local = new List<object>();
                for (int i = 0; i < border; i++)
                {
                    local.Add(normalCollection[i]);
                }

                border++;
                toReturn.Add(new[] {local});
            }

            return toReturn;
        }
    }
}
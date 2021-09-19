using System.Collections.Generic;

namespace Bookworm.Xapi.Tests.Infra
{
    public static class TestDataExtensions
    {
        public static IEnumerable<object[]> ToTestData<T>(this IEnumerable<T> source)
        {
            if (source == null) yield break;

            foreach (var item in source)
            {
                yield return new object[] { item };
            }
        }
    }
}

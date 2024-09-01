using System.Collections.Generic;

namespace Sapiscow.UnityTemplate
{
    public static class ListHelper
    {
        public static void Swap<T>(this List<T> list, int indexA, int indexB)
            => (list[indexB], list[indexA]) = (list[indexA], list[indexB]);
    }
}
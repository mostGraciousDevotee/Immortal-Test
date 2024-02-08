using System;
using UnityEngine;

namespace Immortal.Test
{
    public static class Assert
    {
        public static bool AreEqual<T>(T expected, T result, string errorMessage) where T : IEquatable<T>
        {
            if (!expected.Equals(result))
            {
                Debug.Log(errorMessage);
                return false;
            }

            return true;
        }
    }
}
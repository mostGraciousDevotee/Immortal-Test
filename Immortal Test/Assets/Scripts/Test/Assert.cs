using System;
using System.Collections.Generic;
using UnityEngine;

namespace Immortal.Test
{
    public static class Assert
    {
        public static bool AreEqual<T>(T expected, T result, string errorMessage) where T : IEquatable<T>
        {
            if (!expected.Equals(result))
            {
                Debug.LogError(errorMessage);
                return false;
            }

            return true;
        }

        public static bool AreEqualRef<T>(T expected, T result, string errorMessage)
        {
            if (!ReferenceEquals(expected, result))
            {
                Debug.LogError(errorMessage);
                return false;
            }

            return true;
        }

        public static bool IsContaining<T>(ICollection<T> collection, T item, string errorMessage)
        {
            if (!collection.Contains(item))
            {
                Debug.LogError(errorMessage);
                return false;
            }
            
            return true;
        }
    }
}
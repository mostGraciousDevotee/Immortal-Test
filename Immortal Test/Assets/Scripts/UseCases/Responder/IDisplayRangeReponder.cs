using System;
using System.Collections.Generic;
using UnityEngine;

namespace Immortal.Responder
{
    public interface IDisplayRangeResponder
    {
        event Action<string, int, List<Vector2Int>> ShowValidRange;
        event Action Unshow;

        void Respond();
        void Unrespond();
    }
}
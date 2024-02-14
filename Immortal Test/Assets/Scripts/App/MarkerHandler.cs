using System.Collections.Generic;
using Immortal.App;
using Immortal.Entities;

namespace Immortal.App
{
    public class MarkerHandler : IMarkerHandler
    {
        IMarker _marker;
        Dictionary<IUnit, IUnitView> _unitViewDict = new Dictionary<IUnit, IUnitView>();

        public MarkerHandler(IMarker marker, Dictionary<IUnit, IUnitView> unitViewDict)
        {
            _marker = marker;
            _unitViewDict = unitViewDict;
        }

        public void Mark(IUnit unit)
        {
            var unitView = _unitViewDict[unit];
            _marker.Mark(unitView);
        }
    }
}
using System.Collections.Generic;
using Immortal.UnitSystem;

namespace Immortal.App
{
    public class MarkerHandler : IMarkerHandler
    {
        IMarker _marker;
        Dictionary<IUnit, IUnitPresenter> _unitViewDict = new Dictionary<IUnit, IUnitPresenter>();

        public MarkerHandler(IMarker marker, Dictionary<IUnit, IUnitPresenter> unitViewDict)
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
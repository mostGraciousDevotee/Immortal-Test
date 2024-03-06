using Immortal.PresenterFactory;
using Immortal.Presenter;
using Immortal.GameSystem;

namespace Immortal.GameFactory
{
    public interface IGameBuilder
    {
        void Build(IGame game, IUnitPresenters unitPresenters, IMarker marker);
    }
}
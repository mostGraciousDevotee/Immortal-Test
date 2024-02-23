using Immortal.Entities;

namespace Immortal.App
{
    public abstract class DisplayRange : ActionCommand
    {
        ICommandHistory _commandHistory;
        ICellValidator _cellValidator;

        ICellDisplays _cellDisplays;
        ICellDisplay _cellDisplayPrefab;
        IHideable _actionPanel;

        protected DisplayRange
        (
            ITurnManager turnManager,
            ICommandHistory commandHistory,
            ICellValidator cellValidator,
            ICellDisplays cellDisplays,
            ICellDisplay cellDisplayPrefab,
            IHideable actionPanel
        ) : base(turnManager)
        {
            _commandHistory = commandHistory;
            _cellValidator = cellValidator;

            _cellDisplays = cellDisplays;
            _cellDisplayPrefab = cellDisplayPrefab;
            _actionPanel = actionPanel;
        }

        public sealed override void Execute()
        {
            var currentUnit = _turnManager.CurrentUnit;
            var unitPos = currentUnit.Position;

            var range = GetRange(currentUnit);

            var validPositions = _cellValidator.GetValidCells(unitPos, range);

            _cellDisplays.Show(_cellDisplayPrefab, validPositions);
            _actionPanel.Hide();
            _commandHistory.Push(this);
        }

        public sealed override void Undo()
        {
            _actionPanel.Show();
            _cellDisplays.Hide();
        }

        protected abstract int GetRange(IUnit currentUnit);
    }
}
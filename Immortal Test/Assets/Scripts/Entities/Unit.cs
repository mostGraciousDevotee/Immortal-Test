namespace Immortal.Entities
{
    public class Unit : IUnit
    {
        string _name;
        int _speed;
        int _readiness;
        const int READY_TO_ACT = 100;

        public Unit(string name, int speed)
        {
            _name = name;
            _speed = speed;
        }

        public string Name => _name;
        public int Speed => _speed;
    }

    public interface IUnit
    {
        string Name { get; }
        int Speed { get; }
    }
}
namespace Immortal.Test
{
    public abstract class BaseTest
    {
        public abstract bool Test();

        protected string ErrorMessage
        {
            get => this.ToString() + " assertion failed";
        }
    }
}
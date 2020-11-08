namespace Almotkaml.Repository
{
    public interface INumbered
    {
        int GetMaxNumber();
    }

    public interface INumbered<out TKey>
    {
        TKey GetMaxNumber();
    }
}
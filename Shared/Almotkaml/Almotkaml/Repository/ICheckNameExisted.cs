namespace Almotkaml.Repository
{
    public interface ICheckNameExisted
    {
        bool NameIsExisted(string name);
        bool NameIsExisted(string name, int idToExcept);
    }

    public interface ICheckNameExisted<in TId>
    {
        bool NameIsExisted(string name);
        bool NameIsExisted(string name, TId idToExcept);
    }
}
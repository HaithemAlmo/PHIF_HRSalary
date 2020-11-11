namespace Almotkaml.Repository
{
    public interface ICheckNationalNumberExisted
    {
        bool NameIsExisted(string Name);
   //     bool NameIsExisted(string name, int idToExcept);
    }

    public interface ICheckNationalNumberExisted<in TId>
    {
        bool NameIsExisted(int NationalNumber);
    //    bool NameIsExisted(string name, TId idToExcept);
    }
}
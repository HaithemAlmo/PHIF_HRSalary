namespace Almotkaml.Business
{
    public interface ISettingsBusiness<TModel>
    {
        TModel Get();
        bool Save(TModel model);
    }
}
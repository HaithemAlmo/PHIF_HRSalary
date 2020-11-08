namespace Almotkaml.Business
{
    public interface ISimpleBusiness<TModel, in TId>
    {
        TModel Prepare();
        void Refresh(TModel model);
        bool Select(TModel model);
        bool Create(TModel model);
        bool Edit(TModel model);
        bool Delete(TModel model);
    }
}
namespace Almotkaml.Business
{
    public interface IDefaultBusiness<out TIndexModel, TFormModel, in TId>
    {
        TIndexModel Index();
        void Refresh(TFormModel model);
        TFormModel Prepare();
        bool Create(TFormModel model);
        TFormModel Find(TId id);
        bool Edit(TId id, TFormModel model);
        bool Delete(TId id, TFormModel model);
    }
}
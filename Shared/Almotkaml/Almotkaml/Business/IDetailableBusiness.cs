namespace Almotkaml.Business
{
    public interface IDetailableBusiness<in TFormModel, in TId>
    {
        void UpdateDetails(TFormModel model, TId detailId);
        void DeleteDetails(TId detailId);
        bool Create(TFormModel model, bool withDetails);
        bool Edit(TId id, TFormModel model, bool withDetails);
    }
}
namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    //public class DevelopmentTypeEBusiness : Business, IDevelopmentTypeEBusiness
    //{
    //    public DevelopmentTypeEBusiness(HumanResource humanResource)
    //        : base(humanResource)
    //    {
    //    }

    //    private bool HavePermission(bool permission = true)
    //        => ApplicationUser.Permissions.DevelopmentTypeE && permission;

    //    public DevelopmentTypeEModel Prepare()
    //    {
    //        if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeE_Create))
    //            return Null<DevelopmentTypeEModel>(RequestState.NoPermission);

    //        return new DevelopmentTypeEModel()
    //        {
    //            CanCreate = ApplicationUser.Permissions.DevelopmentTypeE_Create,
    //            CanEdit = ApplicationUser.Permissions.DevelopmentTypeE_Edit,
    //            CanDelete = ApplicationUser.Permissions.DevelopmentTypeE_Delete,
    //            DevelopmentTypeAList = UnitOfWork.DevelopmentTypeAs.GetAll().ToList(),
    //            Grid = UnitOfWork.DevelopmentTypeEs.GetDevelopmentTypeEWithDevelopmentTypeD().ToGrid()
    //        };
    //    }

    //    public void Refresh(DevelopmentTypeEModel model)
    //    {
    //        if (model == null)
    //            return;

    //        model.DevelopmentTypeBList = model.DevelopmentTypeAId > 0
    //            ? UnitOfWork.DevelopmentTypeBs.GetDevelopmentTypeBWithDevelopmentTypeA(model.DevelopmentTypeAId).ToList()
    //            : new HashSet<DevelopmentTypeBListItem>();

    //        model.DevelopmentTypeCList = model.DevelopmentTypeBId > 0
    //            ? UnitOfWork.DevelopmentTypeCs.GetDevelopmentTypeCWithDevelopmentTypeB(model.DevelopmentTypeBId).ToList()
    //            : new HashSet<DevelopmentTypeCListItem>();

    //        model.DevelopmentTypeDList = model.DevelopmentTypeCId > 0
    //            ? UnitOfWork.DevelopmentTypeDs.GetDevelopmentTypeDWithDevelopmentTypeC(model.DevelopmentTypeCId).ToList()
    //            : new HashSet<DevelopmentTypeDListItem>();

    //    }

    //    public bool Select(DevelopmentTypeEModel model)
    //    {
    //        if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeE_Edit))
    //            return Fail(RequestState.NoPermission);
    //        if (model.DevelopmentTypeEId <= 0)
    //            return Fail(RequestState.BadRequest);

    //        var developmentTypeE = UnitOfWork.DevelopmentTypeEs.Find(model.DevelopmentTypeEId);

    //        if (developmentTypeE == null)
    //            return Fail(RequestState.NotFound);

    //        var developmentTypeAId = developmentTypeE.DevelopmentTypeD?.DevelopmentTypeC?.DevelopmentTypeB?.DevelopmentTypeAId ?? 0;
    //        var developmentTypeBId = developmentTypeE.DevelopmentTypeD?.DevelopmentTypeC?.DevelopmentTypeBId ?? 0;
    //        var developmentTypeCId = developmentTypeE.DevelopmentTypeD?.DevelopmentTypeCId ?? 0;
    //        model.DevelopmentTypeAId = developmentTypeAId;
    //        model.DevelopmentTypeBId = developmentTypeBId;
    //        model.DevelopmentTypeCId = developmentTypeCId;
    //        model.DevelopmentTypeDId = developmentTypeE.DevelopmentTypeDId;
    //        model.DevelopmentTypeDList = UnitOfWork.DevelopmentTypeDs.GetDevelopmentTypeDWithDevelopmentTypeC(developmentTypeCId).ToList();
    //        model.DevelopmentTypeCList = UnitOfWork.DevelopmentTypeCs.GetDevelopmentTypeCWithDevelopmentTypeB(developmentTypeBId).ToList();
    //        model.DevelopmentTypeBList = UnitOfWork.DevelopmentTypeBs.GetDevelopmentTypeBWithDevelopmentTypeA(developmentTypeAId).ToList();
    //        model.Name = developmentTypeE.Name;
    //        return true;
    //    }

    //    public bool Create(DevelopmentTypeEModel model)
    //    {
    //        if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeE_Create))
    //            return Fail(RequestState.NoPermission);

    //        if (!ModelState.IsValid(model))
    //            return false;

    //        if (UnitOfWork.DevelopmentTypeEs.DevelopmentTypeEExisted(model.Name, model.DevelopmentTypeDId))
    //            return NameExisted();

    //        var developmentTypeE = DevelopmentTypeE.New(model.Name, model.DevelopmentTypeDId);

    //        UnitOfWork.DevelopmentTypeEs.Add(developmentTypeE);

    //        UnitOfWork.Complete(n => n.DevelopmentTypeE_Create);

    //        return SuccessCreate();
    //    }

    //    public bool Edit(DevelopmentTypeEModel model)
    //    {
    //        if (model.DevelopmentTypeEId <= 0)
    //            return Fail(RequestState.BadRequest);

    //        if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeE_Edit))
    //            return Fail(RequestState.NoPermission);

    //        if (!ModelState.IsValid(model))
    //            return false;

    //        var developmentTypeE = UnitOfWork.DevelopmentTypeEs.Find(model.DevelopmentTypeEId);

    //        if (developmentTypeE == null)
    //            return Fail(RequestState.NotFound);
    //        if (UnitOfWork.DevelopmentTypeEs.DevelopmentTypeEExisted(model.Name, model.DevelopmentTypeDId, model.DevelopmentTypeEId))
    //            return NameExisted();

    //        developmentTypeE.Modify(model.Name, model.DevelopmentTypeDId);

    //        UnitOfWork.Complete(n => n.DevelopmentTypeE_Edit);

    //        return SuccessEdit();
    //    }

    //    public bool Delete(DevelopmentTypeEModel model)
    //    {
    //        if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeE_Delete))
    //            return Fail(RequestState.NoPermission);

    //        if (model.DevelopmentTypeEId <= 0)
    //            return Fail(RequestState.BadRequest);

    //        var developmentTypeE = UnitOfWork.DevelopmentTypeEs.Find(model.DevelopmentTypeEId);

    //        if (developmentTypeE == null)
    //            return Fail(RequestState.NotFound);

    //        UnitOfWork.DevelopmentTypeEs.Remove(developmentTypeE);

    //        if (!UnitOfWork.TryComplete(n => n.DevelopmentTypeE_Delete))
    //            return Fail(UnitOfWork.Message);

    //        return SuccessDelete();
    //    }



    //}
}
using Almotkaml.Extensions;
using Almotkaml.Models;
using Almotkaml.Repository;
using Almotkaml.Resources;
using System;
using System.Linq.Expressions;

namespace Almotkaml
{
    public abstract class Business<TApplication, TLoginModel, TUnitOfWork, TManager, TUser, TApplicationUser, TApplicationUserInterface, TSettings, TPermission, TCompanyInfo>
        where TApplication : Application<TLoginModel, TUnitOfWork, TManager, TUser, TApplicationUser, TApplicationUserInterface, TSettings, TPermission, TCompanyInfo>
        where TUnitOfWork : class, IDisposable
        where TLoginModel : class, ILoginModel
        where TApplicationUser : ApplicationUser<TPermission, TUser, TLoginModel, TApplicationUserInterface>, IApplicationUser<TPermission>, new()
        where TApplicationUserInterface : IApplicationUser<TPermission>
        where TManager : ApplicationManager<TLoginModel, TUser, TUnitOfWork, TSettings, TCompanyInfo>, new()
        where TCompanyInfo : class
        where TSettings : class
        where TUser : class
    {
        protected Business(TApplication application)
        {
            Application = application;
        }

        private TApplication Application { get; }
        protected ModelState ModelState => Application.ModelState;
        protected TSettings Settings => Application.Settings;
        protected TCompanyInfo CompanyInfo => Application.CompanyInfo;
        protected TApplicationUser ApplicationUser => Application.ApplicationUser;

        protected TUnitOfWork UnitOfWork => Application.UnitOfWork;

        protected TModel Null<TModel>(RequestState state) where TModel : class
        {

            Application.RequestState = state;
            return null;
        }

        protected bool Fail(RequestState state)
        {
            Application.RequestState = state;
            return false;
        }
        protected bool CheckBoxNumber()
        {
            Application.Message = SharedMessages.CheckBoxNumber;
            return true;
        }
        protected bool CheckBoxNumber2()
        {
            Application.Message = SharedMessages.CheckBoxNumber2;
            return true;
        }
        protected bool NameExisted(Expression<Func<object, object>> expression)
            => NameExisted(expression.ToExpressionTarget());

        protected bool NameExisted(string propertyName = null)
        {
            if (propertyName != null)
                ModelState.AddError(propertyName, SharedMessages.NameExisted);

            Application.Message = SharedMessages.NameExisted;
            return false;
        }

        protected bool LoginFailed(Expression<Func<object, object>> expression)
            => LoginFailed(expression.ToExpressionTarget());

        protected bool LoginFailed(string propertyName = null)
        {
            if (propertyName != null)
                ModelState.AddError(propertyName, SharedMessages.LoginFailed);

            Application.Message = SharedMessages.LoginFailed;
            return false;
        }
        protected bool ErrorNationaltyNumber()
        {
            Application.Message = SharedMessages.NumberN;
            return true;
        }
        protected bool Duplicate()
        {
            Application.Message = SharedMessages.ExisteNumber;
            return true;
        }
        protected bool SuccessCreate()
        {
            Application.Message = SharedMessages.SuccessCreate;
            return true;
        }
        protected bool SuccessEdit()
        {
            Application.Message = SharedMessages.SuccessEdit;
            return true;
        }
        protected bool SuccessDelete()
        {
            Application.Message = SharedMessages.SuccessDelete;
            return true;
        }

        protected bool Success(string message)
        {
            Application.Message = message;
            return true;
        }
        protected bool YearHauj( ) 
        {
            Application.Message = SharedMessages.yearHauj ;
            return true;
        }
        protected bool ExistVacation()
        {
            Application.Message = SharedMessages.existvacation;
            return true;
        }
        protected bool MarriageLeave()
        {
            Application.Message = SharedMessages.marriageleave;
            return true;
        }
        protected bool VacationEmergency()
        {
            Application.Message = SharedMessages.vacationemergency;
            return true;
        }
        protected bool VacationSick()
        {
            Application.Message = SharedMessages.vacationsick;
            return true;
        }
        protected bool sickLeave()
        {
            Application.Message = SharedMessages.sickleave;
            return true;
        }
        protected bool ConditionVacationSick()
        {
            Application.Message = SharedMessages.conditionvacationsick;
            return true;
        }
   
        protected bool ConditionVacationPaternityLeave()
        {
            Application.Message = SharedMessages.conditionvacationpaternityLeave;
            return true;
        }
        protected bool ConditionVacationPaternityLeaveKidsTwo()
        {
            Application.Message = SharedMessages.KidstwoMessage;
            return true;
        }
        protected bool ConditionVacationPaternityLeaveKidsOne()
        {
            Application.Message = SharedMessages.KidsOne;
            return true;
        }
        protected bool ConditionVacationEmergency()
        {
            Application.Message = SharedMessages.conditionvacationemergency;
            return true;
        }
        protected bool Fail(string message)
        {
            Application.RequestState = RequestState.Invalid;
            Application.Message = message;
            return false;
        }
        protected bool LimitExceeded<TRepository>(TRepository repository, RepositoryLimit limit = RepositoryLimit.Ten)
            where TRepository : ILimitedInDemoRepository
        {
            if (!Application.StartUp.AppConfig.IsDemo || repository.LimitReached() < (int)limit)
                return false;

            Application.Message = SharedMessages.LimitExceeded + " " + (int)limit;
            return true;
        }
    }
}
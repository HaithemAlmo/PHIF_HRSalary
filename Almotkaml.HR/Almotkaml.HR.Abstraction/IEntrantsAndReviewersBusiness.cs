using Almotkaml.Business;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Abstraction
{
    //public interface  IEntrantsAndReviewersBusiness : IDefaultBusiness<EntrantsAndReviewersModel, EntrantsAndReviewersModel, int>
    //{
    //    bool Edit(EntrantsAndReviewersModel model);
    //}

    public interface IEntrantsAndReviewersBusiness : ISimpleBusiness<EntrantsAndReviewersModel, int>
    {

    }
}

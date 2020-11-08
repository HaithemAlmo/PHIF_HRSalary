﻿using Almotkaml.Business;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IEndServicesBusiness : IDefaultBusiness<EndServicesIndexModel, EndServicesFormModel, int>
    {
        bool View(SettlementReportModel model);

    }
}
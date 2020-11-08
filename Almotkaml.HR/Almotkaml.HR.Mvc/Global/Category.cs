using Almotkaml.Extensions;
using Almotkaml.HR.Mvc.Controllers;
using Almotkaml.HR.Mvc.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Resources;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Global
{
    public class BaseCategory
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public ICollection<Categry> Categories { get; } = new HashSet<Categry>();
    }

    public class Categry
    {
        private string _controllerName;
        private string _actionName;

        public string ControllerName
        {
            get { return _controllerName; }
            set { _controllerName = value.Replace("Controller", ""); }
        }
        public string ActoinName
        {
            get { return _actionName; }
            set { _actionName = value.Replace("Action", ""); }
        }

        public string Title { get; set; }
        public string Icon { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<string> AddedPermissions { get; } = new HashSet<string>();
    }

    public class AllTrue
    {
        public AllTrue()
        {
            _areTrue = true;
        }
        private bool _areTrue;

        public bool AreTrue
        {
            get { return _areTrue; }
            set
            {
                if (_areTrue)
                    _areTrue = value;
            }
        }
    }

    public class Category
    {
        private ICollection<BaseCategory> Categories { get; set; }

        public static string GetPermissionPhrase(string name, Permission permission)
        {
            var secondName = name.Contains("_") ? name.Split('_')[1] : name;

            switch (secondName)
            {
                case "Create":
                    return "إضافة";
                case "Edit":
                    return "تعديل";
                case "Delete":
                    return "حذف";
            }

            var resxName = permission.GetAttribute<DisplayAttribute>(name)?.Name;

            return resxName != null
                ? new ResourceManager(typeof(Resources.Titles)).GetString(resxName)
                : secondName;
        }

        public ICollection<BaseCategory> GetCategories(HtmlHelper htmlHelper)
        {
            if (Categories != null)
                return Categories;

            var permissions = htmlHelper.GetPermissions();

            if (permissions == null)
                throw new Exception("No permissions loaded");

            var settings = htmlHelper.GetSettings();

            if (settings == null)
                throw new Exception("No settings loaded");

            Categories = new HashSet<BaseCategory>()
            {
                #region الإعدادات العامة
            
                    new BaseCategory()
                    {
                        Title = "الإعدادات العامة",
                        Icon = "cogs",
                        Categories =
                        {
                            new Categry()
                            {
                                Title = "إعدادات المنظومة",
                                ControllerName = nameof(SettingController),
                                ActoinName=nameof(SettingController.Index ),
                                Icon = "cog",
                                IsVisible = permissions.Setting,
                            },
                            new Categry()
                            {
                                Title = "بيانات الجهة",
                                ControllerName = nameof(CompanyInfoController),
                                ActoinName=nameof(CompanyInfoController.Index ),
                                Icon = "info",
                                IsVisible = permissions.CompanyInfo,
                            },
                            new Categry()
                            {
                                Title = "صلاحيات المستخدمين",
                                ControllerName = nameof(UserGroupController),
                                ActoinName=nameof(UserGroupController.Index ),
                                Icon = "users",
                                IsVisible = permissions.UserGroup,
                            },
                            new Categry()
                            {
                                Title = "إدارة المستخدمين",
                                ControllerName = nameof(UserController),
                                ActoinName=nameof(UserController.Index ),
                                Icon = "user",
                                IsVisible = permissions.User,
                            },
                            new Categry()
                            {
                                Title = "مراقبة المستخدمين",
                                ControllerName = nameof(UserActivityController),
                                ActoinName=nameof(UserActivityController.Index ),
                                Icon = "eye",
                                IsVisible = permissions.UserActivity,
                            },
                            new Categry()
                            {
                                Title = "النسخ الاحتياطي",
                                ControllerName = nameof(BackUpRestoreController),
                                ActoinName=nameof(BackUpRestoreController.Index ),
                                Icon = "database",
                                IsVisible = permissions.BackUp || permissions.Restore,
                                AddedPermissions = {nameof(permissions.BackUp), nameof(permissions.Restore)}
                            },
                        },
                    },
                    #endregion
                #region الإعدادات الأساسية
                
                    new BaseCategory()
                    {
                        Title = "الإعدادات الأساسية",
                        Icon = "wrench",
                        Categories =
                        {
                            new Categry()
                            {
                                Title = "الجنسيات",
                                ControllerName = nameof(NationalityController),
                                ActoinName=nameof(NationalityController.Index ),
                                Icon = "address-card",
                                IsVisible = permissions.Nationality,
                            },
                            new Categry()
                            {
                                Title = "البلدان",
                                ControllerName = nameof(CountryController),
                                ActoinName=nameof(CountryController.Index ),
                                Icon = "globe",
                                IsVisible = permissions.Country,
                            },
                            new Categry()
                            {
                                Title = "المدن",
                                ControllerName = nameof(CityController),
                                ActoinName=nameof(CityController.Index ),
                                Icon = "building-o",
                                IsVisible = permissions.City,
                            },
                            new Categry()
                            {
                                Title = "الفرع البلدي",
                                ControllerName = nameof(BranchController),
                                ActoinName=nameof(BranchController.Index ),
                                Icon = "object-group",
                                IsVisible = permissions.Branch,
                            },
                            new Categry()
                            {
                                Title = "المحلة / الشارع",
                                ControllerName = nameof(PlaceController),
                                ActoinName=nameof(PlaceController.Index ),
                                Icon = "share-alt-square",
                                IsVisible = permissions.Place,
                            },
                            new Categry()
                            {
                                Title = "العطل",
                                ControllerName = nameof(HolidayController),
                                ActoinName=nameof(HolidayController.Index ),
                                Icon = "calendar-minus-o",
                                IsVisible = permissions.Holiday,
                            },
                            new Categry()
                            {
                                Title = "أنواع المكافآت",
                                ControllerName = nameof(RewardTypeController),
                                ActoinName=nameof(RewardTypeController.Index ),
                                Icon = "thumbs-o-up",
                                IsVisible = permissions.RewardType,
                            },
                            new Categry()
                            {
                                Title = "أنواع العقوبات",
                                ControllerName = nameof(SanctionTypeController),
                                ActoinName=nameof(SanctionTypeController.Index ),
                                Icon = "thumbs-o-down",
                                IsVisible = permissions.SanctionType,
                            },
                            new Categry()
                            {
                                Title = "أنواع الإجازات",
                                ControllerName = nameof(VacationTypeController),
                                ActoinName=nameof(VacationTypeController.Index ),
                                Icon = "sign-out",
                                IsVisible = permissions.VacationType,
                            },
                            new Categry()
                            {
                                Title = "أنواع الوثائق",
                                ControllerName = nameof(DocumentTypeController),
                                ActoinName=nameof(DocumentTypeController.Index ),
                                Icon = "file-pdf-o",
                                IsVisible = permissions.DocumentType,
                            },

                        },
                    },
                    #endregion
                #region إعدادات الهيكلية التنظيمية
                
                    new BaseCategory()
                    {
                        Title = "إعدادات الهيكلية التنظيمية",
                        Icon = "puzzle-piece",
                        Categories =
                        {
                            new Categry()
                            {
                                Title = "الوحدات التنظيمية",
                                ControllerName = nameof(CenterController),
                                ActoinName=nameof(CenterController.Index ),
                                Icon = "sitemap",
                                IsVisible = permissions.Center,
                            },
                            new Categry()
                            {
                                Title = "الإدارات / المكاتب",
                                ControllerName = nameof(DepartmentController),
                                ActoinName=nameof(DepartmentController.Index ),
                                Icon = "share-alt",
                                IsVisible = permissions.Department,
                            },
                            new Categry()
                            {
                                Title = "الأقسام",
                                ControllerName = nameof(DivisionController),
                                ActoinName=nameof(DivisionController.Index ),
                                Icon = "cubes",
                                IsVisible = permissions.Division,
                            },
                            new Categry()
                            {
                                Title = "الوحدات",
                                ControllerName = nameof(UnitController),
                                ActoinName=nameof(UnitController.Index ),
                                Icon = "cube",
                                IsVisible = permissions.Unit,
                            },
                            new Categry()
                            {
                                Title = "المسمى الوظيفي",
                                ControllerName = nameof(JobController),
                                ActoinName=nameof(JobController.Index ),
                                Icon = "briefcase",
                                IsVisible = permissions.Job,
                            },
                            new Categry()
                            {
                                Title = "الوضع الوظيفي",
                                ControllerName = nameof(AdjectiveEmployeeTypeController),
                                ActoinName=nameof(AdjectiveEmployeeTypeController.Index ),
                                Icon = "tags",
                                IsVisible = permissions.AdjectiveEmployeeType,
                            },
                            //new Categry()
                            //{
                            //    Title = "صفة الموظف",
                            //    ControllerName = nameof(AdjectiveEmployeeController),
                            //    ActoinName=nameof(AdjectiveEmployeeController.Index ),
                            //    Icon = "address-book-o",
                            //    IsVisible = permissions.AdjectiveEmployee,
                            //},
                            new Categry()
                            {
                                Title = "نوع الملاك الوظيفي",
                                ControllerName = nameof(StaffingTypeController),
                                ActoinName=nameof(StaffingTypeController.Index ),
                                Icon = "language",
                                IsVisible = permissions.StaffingType,
                            },
                            new Categry()
                            {
                                Title = "التصنيف الوظيفي حسب الملاك",
                                ControllerName = nameof(StaffingController),
                                ActoinName=nameof(StaffingController.Index ),
                                Icon = "compass",
                                IsVisible = permissions.Staffing,
                            },
                             new Categry()
                            {
                                Title = "التصنيف حسب الملاك",
                                ControllerName = nameof(StaffingClassificationController),
                                ActoinName=nameof(StaffingClassificationController.Index ),
                                Icon = "compass",
                                IsVisible = permissions.StaffingClassification,
                            },
                            new Categry()
                            {
                                Title = "التصنيف بحسب قانون العمل",
                                ControllerName = nameof(ClassificationOnWorkController),
                                ActoinName=nameof(ClassificationOnWorkController.Index ),
                                Icon = "list-alt",
                                IsVisible = permissions.ClassificationOnWork,
                            },
                              new Categry()
                            {
                                Title = "التصنيف بحسب لائحة الباحثين",
                                ControllerName = nameof(ClassificationOnSearchingController),
                                ActoinName=nameof(ClassificationOnSearchingController.Index ),
                                Icon = "indent",
                                IsVisible = permissions.ClassificationOnSearching,
                            },
                            new Categry()
                            {
                                Title = "الوضع الحالي للموظف",
                                ControllerName = nameof(CurrentSituationController),
                                ActoinName=nameof(CurrentSituationController.Index ),
                                Icon = "hand-o-down",
                                IsVisible = permissions.CurrentSituation,
                            },
                        },
                    },
                    #endregion
                #region إعدادات البيانات العلمية
                new BaseCategory()
                {
                    Title = "إعدادات البيانات العلمية",
                    Icon = "book",
                    Categories =
                    {
                        new Categry()
                        {
                            Title = "المؤهل العلمي",
                            ControllerName = nameof(QualificationTypeController),
                            ActoinName=nameof(QualificationTypeController.Index ),
                            Icon = "graduation-cap",
                            IsVisible = permissions.QualificationType,
                        },
                        new Categry()
                        {
                            Title = "التخصص الأساسي",
                            ControllerName = nameof(SpecialtyController),
                            ActoinName=nameof(SpecialtyController.Index ),
                            Icon = "magic",
                            IsVisible = permissions.Specialty,
                        },
                        new Categry()
                        {
                            Title = "التخصص الفرعي",
                            ControllerName = nameof(SubSpecialtyController),
                            ActoinName=nameof(SubSpecialtyController.Index ),
                            Icon = "paint-brush",
                            IsVisible = permissions.SubSpecialty,
                        },
                        new Categry()
                        {
                            Title = "التخصص الدقيق",
                            ControllerName = nameof(ExactSpecialtyController),
                            ActoinName=nameof(ExactSpecialtyController.Index ),
                            Icon = "star-o",
                            IsVisible = permissions.ExactSpecialty,
                        },
                    },
                },
                #endregion
                #region إعدادات البيانات المالية
                
                new BaseCategory()
                {
                    Title = "مصارف و فروع",
                    Icon = "bank",
                    Categories =
                    {
                        new Categry()
                        {
                            Title = "المصارف",
                            ControllerName = nameof(BankController),
                            ActoinName=nameof(BankController.Index ),
                            Icon = "university",
                            IsVisible = permissions.Bank,
                        },
                        new Categry()
                        {
                            Title = "فروع المصارف",
                            ControllerName = nameof(BankBranchController),
                            ActoinName=nameof(BankBranchController.Index ),
                            Icon = "share-alt-square",
                            IsVisible = permissions.BankBranch,
                        },
                    },
                },
                #endregion
                #region شؤون الموظفين
                
                new BaseCategory()
                {
                    Title = "شؤون الموظفين",
                    Icon = "address-book",
                    Categories =
                    {
                        new Categry()
                        {
                            Title = "الموظفين",
                            ControllerName = nameof(EmployeeController),
                            ActoinName=nameof(EmployeeController.Index ),
                            Icon = "user-circle",
                            IsVisible = permissions.Employee,
                            AddedPermissions =
                            {
                                nameof(Permission.Document),
                                nameof(Permission.Document_Create),
                                nameof(Permission.Document_Edit),
                                nameof(Permission.Document_Delete),
                            }
                        },
                        new Categry()
                        {
                            Title = "البيانات العلمية",
                            ControllerName = nameof(QualificationController),
                            ActoinName=nameof(QualificationController.Index ),
                            Icon = "pencil-square-o",
                            IsVisible = permissions.Qualification,
                        },
                //        new Categry()
                //        {
                //            Title = "الدورات التدريبية",
                //            ControllerName = nameof(SelfCourseController),
                //            ActoinName=nameof(SelfCourseController.Index ),
                //            Icon = "street-view",
                //            IsVisible = permissions.SelfCourse,
                //        },
                        new Categry()
                        {
                            Title = "متعاون/منتدب من الجهة",
                            ControllerName = nameof(TransferController),
                            ActoinName=nameof(TransferController.Index ),
                            Icon = "share",
                            IsVisible = permissions.Transfer,
                        },
                        new Categry()
                        {
                            Title = "متعاون/منتدب إلى الجهة",
                            ControllerName = nameof(DelegationController),
                            ActoinName=nameof(DelegationController.Index ),
                            Icon = "handshake-o",
                            IsVisible = permissions.Delegation,
                        },
                    },
                },
                #endregion
                #region العمليات
                new BaseCategory()
                {
                    Title = "العمليات",
                    Icon = "recycle",
                    Categories =
                    {
                        //new Categry()
                        //{
                        //    Title = "العلاوات المستحقة",
                        //    ControllerName = nameof(BounsController),
                        //    ActoinName=nameof(BounsController.Index ),
                        //    Icon = "lightbulb-o",
                        //    IsVisible = permissions.Bouns,
                        //},
                        //new Categry()
                        //{
                        //    Title = "الدرجات المستحقة",
                        //    ControllerName = nameof(DegreeController),
                        //    ActoinName=nameof(DegreeController.Index ),
                        //    Icon = "user-plus",
                        //    IsVisible = permissions.Degree,
                        //},
                          new Categry()
                        {
                            Title = "الترقيات",
                            ControllerName = nameof(JobInfoDegreeController),
                            ActoinName=nameof(JobInfoDegreeController.Index ),
                            Icon = "star",
                            IsVisible = permissions.Employee_Promotion,
                        },
                        new Categry()
                        {
                            Title = "الغياب",
                            ControllerName = nameof(AbsenceController),
                            ActoinName = nameof(AbsenceController.Index),
                            Icon = "times",
                            IsVisible = permissions.Absence,
                        },
                        new Categry()
                        {
                            Title = "الإجازات",
                            ControllerName = nameof(VacationController),
                            ActoinName=nameof(VacationController.Index ),
                            Icon = "plane",
                            IsVisible = permissions.Vacation,
                        },
                        new Categry()
                        {
                            Title = "إضافة رصيد الإجازات",
                            ControllerName = nameof(VacationBalancController),
                            ActoinName=nameof(VacationBalancController.Index ),
                            Icon = "plus-square",
                            IsVisible = permissions.Vacation_BalancYear,
                        },
                        new Categry()
                        {
                            Title = "العقوبات",
                            ControllerName = nameof(SanctionController),
                            ActoinName=nameof(SanctionController.Index ),
                            Icon = "thumbs-down",
                            IsVisible = permissions.Sanction,
                        },
                        new Categry()
                        {
                            Title = "المكافآت",
                            ControllerName = nameof(RewardController),
                            ActoinName=nameof(RewardController.Index ),
                            Icon = "thumbs-up",
                            IsVisible = permissions.Reward,
                        },
                        new Categry()
                        {
                            Title = "العمل الإضافي",
                            ControllerName = nameof(ExtraworkController),
                            ActoinName=nameof(ExtraworkController.Index ),
                            Icon = "plus",
                            IsVisible = permissions.Extrawork,
                        },
                        new Categry()
                        {
                            Title = "التقييم السنوي",
                            ControllerName = nameof(EvaluationController),
                            ActoinName = nameof(EvaluationController.Index),
                            Icon = "balance-scale",
                            IsVisible = permissions.Evaluation,
                        },
                        new Categry()
                        {
                            Title = "تسوية الوضع",
                            ControllerName = nameof(SituationResolveJobController),
                            ActoinName=nameof(SituationResolveJobController.Index ),
                            Icon = "gavel",
                            IsVisible = permissions.SituationResolveJob,
                        },
                        new Categry()
                        {
                            Title = "تنبيه بالمتقاعدين",
                            ControllerName = nameof(RetirementController),
                            ActoinName = nameof(RetirementController.Index),
                            Icon = "unlink",
                            IsVisible = permissions.Retirement,
                        },
                        new Categry()
                        {
                            Title = "إنهاء الخدمة",
                            ControllerName = nameof(EndServicesController),
                            ActoinName = nameof(EndServicesController.Index),
                            Icon = "share-square-o",
                            IsVisible = permissions.EndServices,
                        },
                  },
                },
                #endregion
                #region التدريب
                new BaseCategory()
                {
                    Title = "التدريب",
                    Icon = "tasks",
                    Categories =
                    {
                        new Categry()
                        {
                            Title = "المؤسسات",
                            ControllerName = nameof(CorporationController),
                            ActoinName=nameof(CorporationController.Index ),
                            Icon = "university",
                            IsVisible = permissions.Corporation,
                        },
                        new Categry()
                        {
                            Title = "الدورات",
                            ControllerName = nameof(CourseController),
                            ActoinName=nameof(CourseController.Index ),
                            Icon = "tv",
                            IsVisible = permissions.Course,
                        },
                        new Categry()
                        {
                            Title = "المدربين",
                            ControllerName = nameof(CoachController),
                            ActoinName=nameof(CoachController.Index ),
                            Icon = "male",
                            IsVisible = permissions.Coach,
                        },
                        new Categry()
                        {
                            Title = "حالة التطوير",
                            ControllerName = nameof(DevelopmentStateController),
                            ActoinName=nameof(DevelopmentStateController.Index ),
                            Icon = "line-chart",
                            IsVisible = permissions.DevelopmentState,
                        },
                        new Categry()
                        {
                            Title = "المؤهل المطلوب",
                            ControllerName = nameof(RequestedQualificationController),
                            ActoinName=nameof(RequestedQualificationController.Index ),
                            Icon = "mortar-board",
                            IsVisible = permissions.RequestedQualification,
                        },
                        new Categry()
                        {
                            Title = "التسجيل",
                            ControllerName = nameof(TrainingController),
                            ActoinName=nameof(TrainingController.Index ),
                            Icon = "file-text",
                            IsVisible = permissions.Training,
                        },
                        new Categry()
                        {
                            Title = "المستوى الاول",
                            ControllerName = nameof(DevelopmentTypeAController),
                            ActoinName=nameof(DevelopmentTypeAController.Index ),
                            Icon = "credit-card",
                            IsVisible = permissions.DevelopmentTypeA,
                        },
                        new Categry()
                        {
                            Title = "المستوى الثاني",
                            ControllerName = nameof(DevelopmentTypeBController),
                            ActoinName=nameof(DevelopmentTypeBController.Index ),
                            Icon = "cc-amex",
                            IsVisible = permissions.DevelopmentTypeB,
                        },
                        new Categry()
                        {
                            Title = "المستوى الثالث",
                            ControllerName = nameof(DevelopmentTypeCController),
                            ActoinName=nameof(DevelopmentTypeCController.Index ),
                            Icon = "cc-discover",
                            IsVisible = permissions.DevelopmentTypeC,
                        },
                        new Categry()
                        {
                            Title = "المستوى الرابع",
                            ControllerName = nameof(DevelopmentTypeDController),
                            ActoinName=nameof(DevelopmentTypeDController.Index ),
                            Icon = "credit-card-alt",
                            IsVisible = permissions.DevelopmentTypeD,
                        },
                    },
                },
                #endregion
                #region المرتبات
                

                new BaseCategory()
                {
                    Title = "المرتبات",
                    Icon = "money",
                    Categories =
                    {
                        new Categry()
                        {
                            Title = "جدول المرتبات",
                            ControllerName = nameof(SalaryUnitController),
                            ActoinName=nameof(SalaryUnitController.Index ),
                            Icon = "newspaper-o",
                            IsVisible = permissions.SalaryUnit,
                        },
                        new Categry()
                        {
                            Title = "البيانات المالية",
                            ControllerName = nameof(SalaryInfoController),
                            ActoinName=nameof(SalaryInfoController.Index ),
                            Icon = "file-text-o",
                            IsVisible = permissions.SalaryInfo,
                        },
                        new Categry()
                        {
                            Title = "المرتبات",
                            ControllerName = nameof(SalaryController),
                            ActoinName=nameof(SalaryController.Index ),
                            Icon = "credit-card-alt",
                            IsVisible = permissions.Salary,
                        },
                        new Categry()
                        {
                            Title = "العلاوات والخصم",
                            ControllerName = nameof(PremiumController),
                            ActoinName=nameof(PremiumController.Index ),
                            Icon = "star",
                            IsVisible = permissions.Premium,
                        },
                        new Categry()
                        {
                            Title = "السلف",
                            ControllerName = nameof(AdvancePaymentController),
                            ActoinName=nameof(AdvancePaymentController.Index ),
                            Icon = "envelope-open-o",
                            IsVisible = permissions.AdvancePayment,
                        },
                        new Categry()
                        {
                            Title = "الشهور السابقة",
                            ControllerName = nameof(OldSalaryController),
                            ActoinName=nameof(OldSalaryController.Index ),
                            Icon = "history",
                            IsVisible = permissions.Salary_OldSalary,
                        },
                        new Categry()
                        {
                            Title = "تقارير السلف",
                            ControllerName = nameof(AdvancePaymentReportController),
                            ActoinName=nameof(AdvancePaymentReportController.Index ),
                            Icon = "bar-chart",
                            IsVisible = permissions.AdvancePaymentReport,
                            },
                    },
                },
                #endregion
                #region التقارير
                
                new BaseCategory()
                {
                    Title = "التقارير",
                    Icon = "file-text-o",
                    Categories =
                    {
                        new Categry()
                        {
                            Title = "التقرير الحر",
                            ControllerName = nameof(EmployeeReportController),
                            ActoinName = nameof(EmployeeReportController.Index),
                            Icon = "newspaper-o",
                            IsVisible = permissions.EmployeeReport
                        },
                         new Categry()
                        {
                            Title = "تقرير البيانات العلمية",
                            ControllerName = nameof(QualificationsReportController),
                            ActoinName=nameof(QualificationsReportController.Index ),
                            Icon = "bar-chart",
                            IsVisible = permissions.QualificationType,
                        },
                       new Categry()
                       {
                           Title="تقارير المالية",
                            ControllerName = nameof(SalarySettlementReportController ),
                            ActoinName=nameof(SalarySettlementReportController.Index ),
                            Icon = "newspaper-o",
                            IsVisible = false,

                       },
                        new Categry()
                        {
                            Title = "إنهاء الخدمة",
                            ControllerName = nameof(SettlementReportController),
                             ActoinName=nameof(SettlementReportController.Index ),
                            Icon = "bar-chart",
                            IsVisible = permissions.SettlementReport,
                        },
                        new Categry()
                        {
                            Title = " الإجازات",
                            ControllerName = nameof(SettlementVacationReportController),
                            ActoinName=nameof(SettlementVacationReportController.Index ),
                            Icon = "bar-chart",
                            IsVisible = permissions.SettlementVacationReport,
                        },
                         new Categry()
                        {
                            Title = " التقرير العام",
                            ControllerName = nameof(SettlementReportPublicEmployeeController),
                            ActoinName=nameof(SettlementReportPublicEmployeeController.Index ),
                            Icon = "bar-chart",
                            IsVisible = permissions.SettlementAbsenceReport,
                        },
                           new Categry()
                        {
                            Title = "  كشف الوضع الحالي",
                            ControllerName = nameof(SettlementReportCurrentEmployeeController),
                            ActoinName=nameof(SettlementReportCurrentEmployeeController.Index ),
                            Icon = "bar-chart",
                            IsVisible = permissions.SettlementAbsenceReport,
                        },
                        new Categry()
                        {
                            Title = " الغياب",
                            ControllerName = nameof(SettlementAbsenceReportController),
                            ActoinName=nameof(SettlementAbsenceReportController.Index ),
                            Icon = "bar-chart",
                            IsVisible = permissions.SettlementAbsenceReport,
                        },
                        //new Categry()
                        //{
                        //    Title = " مرتبات",
                        //    ControllerName = nameof(SalarySettlementReportController),
                        //    ActoinName=nameof(SalarySettlementReportController.Index ),
                        //    Icon = "bar-chart",
                        //    IsVisible = permissions.SalarySettlementReport,
                        //},
                        //new Categry()
                        //{
                        //    Title = " الخصميات",
                        //    ControllerName = nameof(DiscountSettlementReportController),
                        //    ActoinName=nameof(DiscountSettlementReportController.Index ),
                        //    Icon = "bar-chart",
                        //    IsVisible = permissions.DiscountSettlementReport,
                        //},
                        new Categry()
                        {
                            Title = " العلاوات",
                            ControllerName = nameof(PremiumSettlementReportController),
                            ActoinName=nameof(PremiumSettlementReportController.Index ),
                            Icon = "bar-chart",
                            IsVisible = permissions.PremiumSettlementReport,
                        },
                        new Categry()
                        {
                            Title = "استمارة المرتبات",
                            ControllerName = nameof(SalaryController),
                            ActoinName = nameof(SalaryController.SalaryFormIndex),
                            Icon = "newspaper-o",
                            IsVisible = permissions.Salary
                        },
                        new Categry()
                        {
                            Title = "بطاقة المرتب",
                            ControllerName = nameof(SalaryController),
                            ActoinName = nameof(SalaryController.CardIndex),

                            Icon = "newspaper-o",
                            IsVisible = permissions.Salary
                        },
                        new Categry()
                        {
                            Title = "كشف الضرائب",
                            ControllerName = nameof(SalaryController),
                            ActoinName = nameof(SalaryController.TaxIndex),

                            Icon = "newspaper-o",
                            IsVisible = permissions.Salary
                        },
                        new Categry()
                        {
                            Title = "كشف التضامن",
                            ControllerName = nameof(SalaryController),
                            ActoinName = nameof(SalaryController.SolidrtyFoundIndex),

                            Icon = "newspaper-o",
                            IsVisible = permissions.Salary
                        },
                          new Categry()
                        {
                            Title = "كشف الضمان الاجتماعي",
                            ControllerName = nameof(SalaryController),
                            ActoinName = nameof(SalaryController.SocialSecurityFundIndex),

                            Icon = "newspaper-o",
                            IsVisible = permissions.Salary
                        },  new Categry()
                        {
                            Title = "كشف السلف والرواتب المقدمة",
                            ControllerName = nameof(SalaryController),
                            ActoinName = nameof(SalaryController.AdvancePaymentIndex),

                            Icon = "newspaper-o",
                            IsVisible = permissions.Salary
                        },  new Categry()
                        {
                            Title = "الحافظة المصرفية",
                            ControllerName = nameof(SalaryController),
                            ActoinName = nameof(SalaryController.ClipordIndex),

                            Icon = "newspaper-o",
                            IsVisible = permissions.Salary
                        },
                        //new Categry()
                        //{
                        //    Title = "كشف الفروقات",
                        //    ControllerName = nameof(SalaryController),
                        //    ActoinName = nameof(SalaryController.DifrancesIndex),

                        //    Icon = "newspaper-o",
                        //    IsVisible = permissions.Salary
                        //},
                         new Categry()
                        {
                            Title = "كشف الخلاصة",
                            ControllerName = nameof(SalaryController),
                            ActoinName = nameof(SalaryController.SummaryIndex),

                            Icon = "newspaper-o",
                            IsVisible = permissions.Salary
                        },


                    },
                },
                #endregion
            };

            return Categories;
        }
    }
}
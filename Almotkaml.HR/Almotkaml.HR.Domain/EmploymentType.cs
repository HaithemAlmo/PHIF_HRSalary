using Almotkaml.HR.Domain.EmploymentTypeFactory;
using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class EmploymentType
    {
        public static INameHolder New()
        {
            return new EmploymentTypeBuilder();
        }
        internal EmploymentType()
        {

        }
        public int EmploymentTypeId { get; internal set; }
        public string Name { get; internal set; }
        public bool DesignationResolutionNumber { get; internal set; } // رقم القرار للتعيين
        public bool DesignationResolutionDate { get; internal set; }// تاريح القرار للتعيين
        public bool DesignationIssue { get; internal set; } // جهة الصدور للتعيين
        public bool ContractDate { get; internal set; }
        public bool ContractDuration { get; internal set; } //مدة العقد
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public EmploymentTypeModifier Modify()
        {
            return new EmploymentTypeModifier(this);
        }
    }
}
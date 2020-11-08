using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class VacationType
    {
        public static VacationType New(string name, int days = 0, int discountPercentage = 0)
        {
            Check.NotEmpty(name, nameof(name));
            var inRange = discountPercentage >= 0 && discountPercentage <= 100;

            if (!inRange)
                throw new ArgumentOutOfRangeException(nameof(discountPercentage));

            var vacationType = new VacationType()
            {
                Name = name,
                Days = days,
                DiscountPercentage = discountPercentage,
                VacationEssential = VacationEssential.UnKounw
            };


            return vacationType;
        }
        internal VacationType()
        {

        }
        public int VacationTypeId { get; private set; }
        public string Name { get; internal set; }
        public int? DiscountPercentage { get; internal set; }
        public int? Days { get; internal set; }
        public VacationEssential VacationEssential { get; internal set; }
        public ICollection<Vacation> Vacations { get; } = new HashSet<Vacation>();
        //public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name, int days = 0, int discountPercentage = 0)
        {
            Check.NotEmpty(name, nameof(name));

            var inRange = discountPercentage >= 0 && discountPercentage <= 100;

            if (!inRange)
                throw new ArgumentOutOfRangeException(nameof(discountPercentage));

            Name = name;
            Days = days;
            DiscountPercentage = discountPercentage;

        }
    }


    //public enum TakeFromBalance
    //{
    //    Yes = 1,
    //    No = 2
    //}
}
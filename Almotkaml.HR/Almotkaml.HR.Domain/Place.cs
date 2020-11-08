using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Place
    {

        public static Place New(string name, int branchId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(branchId, nameof(branchId));


            var place = new Place()
            {
                Name = name,
                BranchId = branchId,
            };


            return place;
        }
        public static Place New(string name, Branch branch)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(branch, nameof(branch));


            var place = new Place()
            {
                Name = name,
                Branch = branch
            };


            return place;
        }
        private Place()
        {

        }
        public int PlaceId { get; private set; }
        public string Name { get; private set; }
        public Branch Branch { get; private set; }
        public int BranchId { get; private set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name, int branchId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(branchId, nameof(branchId));

            Name = name;
            BranchId = branchId;
            Branch = null;

        }

        public void Modify(string name, Branch branch)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(branch, nameof(branch));

            Name = name;
            Branch = branch;

        }

    }
}
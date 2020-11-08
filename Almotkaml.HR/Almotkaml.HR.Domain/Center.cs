using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Center
    {
        public static Center New(string name, int? costCenterId)
        {
            Check.NotEmpty(name, nameof(name));
            if (costCenterId == 0)
                costCenterId = null;
            var center = new Center()
            {
                Name = name,
                CostCenterId = costCenterId
            };

            return center;
        }

        private Center()
        {

        }
        public int CenterId { get; private set; }
        public int CenterNumber { get; set; }
        public string Name { get; private set; }
        public int? CostCenterId { get; private set; }
        public ICollection<Department> Departments { get; } = new HashSet<Department>();
        public void Modify(string name, int? costCenterId)
        {
            Check.NotEmpty(name, nameof(name));
            if (costCenterId == 0)
                costCenterId = null;

            Name = name;
            CostCenterId = costCenterId;

        }

    }
}
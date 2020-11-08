using Almotkaml.HR.Domain.TrainingFactory;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Training
    {
        public static ITrainingTypeHolder New()
        {
            return new TrainingBuilder();
        }

        internal Training()
        {
        }
        public int TrainingId { get; set; }
        public TrainingType TrainingType { get; set; }
        public int? CorporationId { get; set; }
        public Corporation Corporation { get; set; }
        public int DevelopmentTypeDId { get; set; }
        public DevelopmentTypeD DevelopmentTypeD { get; set; }
        public RequestedQualification RequestedQualification { get; set; }
        public int? RequestedQualificationId { get; set; }
        public string ExecutingAgency { get; set; }// الجهة الموفدة
        public string DecisionNumber { get; set; }
        public DateTime DecisionDate { get; set; }
        public DeducationType DeducationType { get; set; }
        public TrainingPlace TrainingPlace { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Subject { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int? DevelopmentStateId { get; set; }
        public DevelopmentState DevelopmentState { get; set; }
        public ICollection<TrainingDetail> TrainingDetails { get; set; } = new HashSet<TrainingDetail>();
        public TrainingModifier Modify()
        {
            return new TrainingModifier(this);
        }
    }
}
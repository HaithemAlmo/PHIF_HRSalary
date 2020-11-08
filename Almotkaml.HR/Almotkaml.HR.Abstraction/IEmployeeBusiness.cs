using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IEmployeeBusiness
    {
        bool Create(QualificationModel model);
        bool Create(PersonalModel model);
        bool Delete(int id, PersonalModel model);
        bool DeleteDocument(DocumentModel model);
        bool DeleteQualification(QualificationModel model);
        bool DeleteImage(int documentImageId);
        bool DeleteMilitaryData(int id, MilitaryDataModel model);
        bool Edit(QualificationModel model);
        bool Edit(int id, PersonalModel model);
        bool Edit(int id, MilitaryDataModel model);
        bool Edit(int id, JobInfoModel model);


        EmployeeFormModel Find(int id);
        EmployeeIndexModel Index();
        byte[] LoadAvatar(int employeeId);
        byte[] LoadImage(int documentImageId);
        PersonalModel Prepare();
        QualificationModel Prepare1();
        void Refresh();
        void Refresh(EmployeeIndexModel model);
        void Refresh(MilitaryDataModel model);
        void Refresh(PersonalModel model);
        void Refresh(DocumentModel model);
        void Refresh(QualificationModel model);

        void Refresh(int id, JobInfoModel model);
        bool SaveDocument(DocumentModel model);
        bool SelectDocument(DocumentModel model);
        bool SaveQualification(QualificationModel model);
        bool SelectQualification(QualificationModel model);
        JobInfoDegreeModel PrepareJobInfoDegree();
        void Refresh(int id, JobInfoDegreeModel model);
        void Refresh(JobInfoDegreeModel model);
        bool Edit(int id, JobInfoDegreeModel model);
        bool PromotionJobInfo(int id, JobInfoDegreeModel model);
        bool SettlementJobInfo(int id, JobInfoDegreeModel model);
    }
}
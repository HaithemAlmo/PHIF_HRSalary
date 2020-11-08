using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.EntityCore.Resource;
using Almotkaml.HR.Resources;
using System.Linq;

namespace Almotkaml.HR.EntityCore
{
    internal static class SeedData
    {
        private static HrDbContext Context { get; set; }
        public static void Load(HrDbContext context)
        {
            Context = context;
            SeedUserWithGroups();
            SeedVacationType();
            SeedCureentSituations();
        }
        private static void SeedCureentSituations()
        {
            if (Context.CurrentSituations.Any())
                return;

            //var LegalExpenses = ObjectCreator.Create<Premium>(typeof(Premium));
            //LegalExpenses.SetValue(v => v.Name, Names.Legal);
            //LegalExpenses.SetValue(v => v.IsSubject, 0);
            //LegalExpenses.SetValue(v => v.IsTemporary, 0);

            var currentSituation = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation.SetValue(v => v.Name, "مستمر");
            currentSituation.SetValue(v => v.SituationEssential, 0);

            var currentSituation1 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation1.SetValue(v => v.Name, Title.Death);
            currentSituation1.SetValue(v => v.SituationEssential, CauseOfEndService.Death);

            var currentSituation2 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation2.SetValue(v => v.Name, Title.Quit);
            currentSituation2.SetValue(v => v.SituationEssential, CauseOfEndService.Quit);

            var currentSituation3 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation3.SetValue(v => v.Name, Title.Retirement);
            currentSituation3.SetValue(v => v.SituationEssential, CauseOfEndService.Retirement);

            var currentSituation4 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation4.SetValue(v => v.Name, Title.EndService);
            currentSituation4.SetValue(v => v.SituationEssential, CauseOfEndService.EndService);

            var currentSituation5 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation5.SetValue(v => v.Name, Title.RetireOptional);
            currentSituation5.SetValue(v => v.SituationEssential, CauseOfEndService.RetireOptional);


            var currentSituation6 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation6.SetValue(v => v.Name, Title.EndDelegation);
            currentSituation6.SetValue(v => v.SituationEssential, CauseOfEndService.EndDelegation);

            var currentSituation7 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation7.SetValue(v => v.Name, Title.EndEmptied);
            currentSituation7.SetValue(v => v.SituationEssential, CauseOfEndService.EndEmptied);

            var currentSituation8 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation8.SetValue(v => v.Name, Title.EndCollaborator);
            currentSituation8.SetValue(v => v.SituationEssential, CauseOfEndService.EndCollaborator);

            var currentSituation9 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation9.SetValue(v => v.Name, Title.EndOut);
            currentSituation9.SetValue(v => v.SituationEssential, CauseOfEndService.EndOut);

            var currentSituation10 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation10.SetValue(v => v.Name, Title.Delegation);
            currentSituation10.SetValue(v => v.SituationEssential, JobTypeTransfer.Delegation + 10);

            var currentSituation11 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation11.SetValue(v => v.Name, Title.Collaborator);
            currentSituation11.SetValue(v => v.SituationEssential, JobTypeTransfer.Collaborator + 10);

            var currentSituation12 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation12.SetValue(v => v.Name, Title.Emptied);
            currentSituation12.SetValue(v => v.SituationEssential, JobTypeTransfer.EmptiedPart + 10);

            var currentSituation13 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation13.SetValue(v => v.Name, Title.EmptiedFull);
            currentSituation13.SetValue(v => v.SituationEssential, JobTypeTransfer.EmptiedFull + 10);


            Context.CurrentSituations.Add(currentSituation);
            Context.CurrentSituations.Add(currentSituation1);
            Context.CurrentSituations.Add(currentSituation2);
            Context.CurrentSituations.Add(currentSituation3);
            Context.CurrentSituations.Add(currentSituation4);
            Context.CurrentSituations.Add(currentSituation5);
            Context.CurrentSituations.Add(currentSituation6);
            Context.CurrentSituations.Add(currentSituation7);
            Context.CurrentSituations.Add(currentSituation8);
            Context.CurrentSituations.Add(currentSituation9);
            Context.CurrentSituations.Add(currentSituation10);
            Context.CurrentSituations.Add(currentSituation11);
            Context.CurrentSituations.Add(currentSituation12);
            Context.CurrentSituations.Add(currentSituation13);


            Context.SaveChanges();
        }
        private static void SeedVacationType()
        {
            if (Context.VacationTypes.Any())
                return;

            //var LegalExpenses = ObjectCreator.Create<Premium>(typeof(Premium));
            //LegalExpenses.SetValue(v => v.Name, Names.Legal);
            //LegalExpenses.SetValue(v => v.IsSubject, IsSubject.IsSubject);
            //LegalExpenses.SetValue(v => v.IsTemporary, IsTemporary.IsNotTemporary);

            var vacationType = ObjectCreator.Create<VacationType>(typeof(VacationType));
            vacationType.SetValue(v => v.Name, Names.VacationYear);
            vacationType.SetValue(v => v.VacationEssential, VacationEssential.Year);

            var vacationTypeTwo = ObjectCreator.Create<VacationType>(typeof(VacationType));
            vacationTypeTwo.SetValue(v => v.Name, Names.VacationWithoutPay);
            vacationTypeTwo.SetValue(v => v.VacationEssential, VacationEssential.WithoutPay);

            var vacationTypeThree = ObjectCreator.Create<VacationType>(typeof(VacationType));
            vacationTypeThree.SetValue(v => v.Name, Names.VacationEmergency);
            vacationTypeThree.SetValue(v => v.VacationEssential, VacationEssential.Emergency);

            var vacationTypeFour = ObjectCreator.Create<VacationType>(typeof(VacationType));
            vacationTypeFour.SetValue(v => v.Name, Names.VacationSick);
            vacationTypeFour.SetValue(v => v.VacationEssential, VacationEssential.Sick);

            var vacationTypeFive = ObjectCreator.Create<VacationType>(typeof(VacationType));
            vacationTypeFive.SetValue(v => v.Name, Names.Vacationalhaju);
            vacationTypeFive.SetValue(v => v.VacationEssential, VacationEssential.alhaju);

            var vacationTypeSix = ObjectCreator.Create<VacationType>(typeof(VacationType));
            vacationTypeSix.SetValue(v => v.Name, Names.Vacationmarriage);
            vacationTypeSix.SetValue(v => v.VacationEssential, VacationEssential.marriage);

            var vacationTypeSeven = ObjectCreator.Create<VacationType>(typeof(VacationType));
            vacationTypeSeven.SetValue(v => v.Name, Names.Vacationmaternityleave);
            vacationTypeSeven.SetValue(v => v.VacationEssential, VacationEssential.maternityleave);
            var sickleave = ObjectCreator.Create<VacationType>(typeof(VacationType));
            sickleave.SetValue(v => v.Name, Names.sickleave);
            sickleave.SetValue(v => v.VacationEssential, VacationEssential.sickleave);
            Context.VacationTypes.Add(vacationType);
            Context.VacationTypes.Add(vacationTypeTwo);
            Context.VacationTypes.Add(vacationTypeThree);
            Context.VacationTypes.Add(vacationTypeFour);
            Context.VacationTypes.Add(vacationTypeFive);
            Context.VacationTypes.Add(vacationTypeSix);
            Context.VacationTypes.Add(vacationTypeSeven);
            Context.VacationTypes.Add(sickleave);
           // Context.Premiums.Add(LegalExpenses);

            Context.SaveChanges();
        }

        private static void SeedCurrentSituation()
        {
            if (Context.CurrentSituations.Any())
                return;

            //var LegalExpenses = ObjectCreator.Create<Premium>(typeof(Premium));
            //LegalExpenses.SetValue(v => v.Name, Names.Legal);
            //LegalExpenses.SetValue(v => v.IsSubject, 0);
            //LegalExpenses.SetValue(v => v.IsTemporary, 0);

            var currentSituation = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation.SetValue(v => v.Name, "مستمر");
            currentSituation.SetValue(v => v.SituationEssential, 0);

            var currentSituation1 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation1.SetValue(v => v.Name, Title.Death);
            currentSituation1.SetValue(v => v.SituationEssential, CauseOfEndService.Death);

            var currentSituation2 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation2.SetValue(v => v.Name, Title.Quit);
            currentSituation2.SetValue(v => v.SituationEssential, CauseOfEndService.Quit);

            var currentSituation3 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation3.SetValue(v => v.Name, Title.Retirement);
            currentSituation3.SetValue(v => v.SituationEssential, CauseOfEndService.Retirement);

            var currentSituation4 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation4.SetValue(v => v.Name, Title.EndService);
            currentSituation4.SetValue(v => v.SituationEssential, CauseOfEndService.EndService);

            var currentSituation5 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation5.SetValue(v => v.Name, Title.RetireOptional);
            currentSituation5.SetValue(v => v.SituationEssential, CauseOfEndService.RetireOptional);


            var currentSituation6 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation6.SetValue(v => v.Name, Title.EndDelegation);
            currentSituation6.SetValue(v => v.SituationEssential, CauseOfEndService.EndDelegation);

            var currentSituation7 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation7.SetValue(v => v.Name, Title.EndEmptied);
            currentSituation7.SetValue(v => v.SituationEssential, CauseOfEndService.EndEmptied);

            var currentSituation8 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation8.SetValue(v => v.Name, Title.EndCollaborator);
            currentSituation8.SetValue(v => v.SituationEssential, CauseOfEndService.EndCollaborator);

            var currentSituation9 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation9.SetValue(v => v.Name, Title.EndOut);
            currentSituation9.SetValue(v => v.SituationEssential, CauseOfEndService.EndOut);

            var currentSituation10 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation10.SetValue(v => v.Name, Title.Delegation);
            currentSituation10.SetValue(v => v.SituationEssential, JobTypeTransfer.Delegation + 10);

            var currentSituation11 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation11.SetValue(v => v.Name, Title.Collaborator);
            currentSituation11.SetValue(v => v.SituationEssential, JobTypeTransfer.Collaborator + 10);

            var currentSituation12 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation12.SetValue(v => v.Name, Title.Emptied);
            currentSituation12.SetValue(v => v.SituationEssential, JobTypeTransfer.EmptiedPart + 10);

            var currentSituation13 = ObjectCreator.Create<CurrentSituation>(typeof(CurrentSituation));
            currentSituation13.SetValue(v => v.Name, Title.EmptiedFull);
            currentSituation13.SetValue(v => v.SituationEssential, JobTypeTransfer.EmptiedFull + 10);


            Context.CurrentSituations.Add(currentSituation);
            Context.CurrentSituations.Add(currentSituation1);
            Context.CurrentSituations.Add(currentSituation2);
            Context.CurrentSituations.Add(currentSituation3);
            Context.CurrentSituations.Add(currentSituation4);
            Context.CurrentSituations.Add(currentSituation5);
            Context.CurrentSituations.Add(currentSituation6);
            Context.CurrentSituations.Add(currentSituation7);
            Context.CurrentSituations.Add(currentSituation8);
            Context.CurrentSituations.Add(currentSituation9);
            Context.CurrentSituations.Add(currentSituation10);
            Context.CurrentSituations.Add(currentSituation11);
            Context.CurrentSituations.Add(currentSituation12);
            Context.CurrentSituations.Add(currentSituation13);

            Context.SaveChanges();
        }

        private static void SeedUserWithGroups()
        {
            if (Context.Users.Any())
                return;

            var stringPermission = new Permission().ToSerializedObject().Replace("false", "true");

            var fullPermission = stringPermission.ToDeserializedObject<Permission>();

            var userGroup = ObjectCreator.Create<UserGroup>(typeof(UserGroup));
            userGroup.SetValue(g => g.Name, "Administrator");
            userGroup.SetValue(g => g.Permissions, fullPermission);

            var stringNotifications = new Notify().ToSerializedObject().Replace("false", "true");

            var fullNotifications = stringNotifications.ToDeserializedObject<Notify>();

            var user = ObjectCreator.Create<User>(typeof(User));
            user.SetValue(g => g.UserGroup, userGroup);
            user.SetValue(g => g.Notify, fullNotifications);
            user.SetValue(g => g.Password, "!QA2ws3ed");
            user.SetValue(g => g.Title, "Almotkaml");
            user.SetValue(g => g.UserName, "Admin");

            Context.Users.Add(user);

        }
    }
}
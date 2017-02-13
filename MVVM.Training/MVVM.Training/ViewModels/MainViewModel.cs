using MVVM.Training.Base;
using MVVM.Training.Models;
using MVVM.Training.Tools;
using System.ComponentModel;
using System;

namespace MVVM.Training.ViewModels {
    public class MainViewModel : ModelBase {
        public MainViewModel() {
            EventManager.GetMembers += OnGetMembers;
            EventManager.GetTeams += OnGetTeams;

            this.MembersPool = new MemberModels();
            this.TeamsPool = new TeamModels();

            this.addMockTeams();
            this.addMockMembers();

            this.OrganizationViewModel = new OrganizationViewModel();
            this.TeamViewModel = new TeamViewModel();
            this.MemberViewModel = new MemberViewModel();
        }

        private TeamModels OnGetTeams() {
            return TeamsPool;
        }

        private MemberModels OnGetMembers() {
            return MembersPool;
        }

        private void addMockMembers() {
            this.MembersPool.Add(new MemberModel("John", "Doe", Gender.Male));
            this.MembersPool.Add(new MemberModel("Jakes", "Doe", Gender.Male));
            this.MembersPool.Add(new MemberModel("Jane", "Doe", Gender.Female));
            this.MembersPool.Add(new MemberModel("Janet", "Doe", Gender.Female));
        }

        private void addMockTeams() {
            this.TeamsPool.Add(new TeamModel("Team A"));
            this.TeamsPool.Add(new TeamModel("Team B"));
            this.TeamsPool.Add(new TeamModel("Team C"));
            this.TeamsPool.Add(new TeamModel("Team D"));
        }

        public void Dispose() {
            base.Dispose();

            EventManager.GetTeams -= OnGetTeams;
            EventManager.GetMembers -= OnGetMembers;
        }

        public OrganizationViewModel OrganizationViewModel { get; set; }
        public TeamViewModel TeamViewModel { get; set; }
        public MemberViewModel MemberViewModel { get; set; }
        public MemberModels MembersPool { get; set; }
        public TeamModels TeamsPool { get; set; }
    }
}

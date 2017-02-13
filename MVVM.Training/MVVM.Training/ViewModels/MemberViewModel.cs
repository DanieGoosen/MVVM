using MVVM.Training.Base;
using MVVM.Training.Models;
using MVVM.Training.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MVVM.Training.ViewModels {
    public class MemberViewModel : ModelBase {
        public MemberViewModel() {
            this.AvailableTeams = Tools.EventManager.OnGetTeams();

            var members = Tools.EventManager.OnGetMembers();
            if (members != null) {
                this.Members = members;
                this.SelectedMember = Members.FirstOrDefault();
            }
        }

        private MemberModels members = new MemberModels();
        /// <summary>
        /// Gets or sets the Members for the ViewModels
        /// </summary>

        public MemberModels Members {
            get { return this.members; }
            set {
                if (this.members != value) {
                    this.members = value;
                    SetPropertyChanged("Members");
                }
            }
        }

        private ICommand _AssignToteamCommand;
        public ICommand AssignToteamCommand {
            get {
                if (_AssignToteamCommand == null) {
                    _AssignToteamCommand = CreateCommand(AssignToteam);
                }
                return _AssignToteamCommand;
            }
        }

        private ICommand _UnassignFromTeamCommand;
        public ICommand UnassignFromTeamCommand {
            get {
                if (_UnassignFromTeamCommand == null) {
                    _UnassignFromTeamCommand = CreateCommand(UnassignFromTeam);
                }
                return _UnassignFromTeamCommand;
            }
        }

        public void UnassignFromTeam(object obj) {

            var team = this.AvailableTeams.FirstOrDefault(t => t.Name == this.SelectedMember.Team);
            if (team != null) {// team has been found
                team.Members.Remove(SelectedMember);
                SelectedMember.SetTeam(null);
                team.SetPropertyChanged("MemberCount");
                team.SetPropertyChanged("TeamInfo");
                SetPropertyChanged("AvailableTeams");
                SetPropertyChanged("SelectedTeam");
                SetPropertyChanged("CanAssignToTeam");
                SetPropertyChanged("CanUnassignToTeam");
            }

            MessageBox.Show(string.Format("{0} has been Unassigned from team: {0}", SelectedMember.Name, SelectedTeam.TeamInfo));
        }


        public void AssignToteam(object obj) {
            if (this.SelectedMember.BelongsToTeam) {
                var team = this.AvailableTeams.FirstOrDefault(t => t.Name == this.SelectedMember.Team);
                if (team != null) {// team has been found
                    team.Members.Remove(SelectedMember);
                    team.SetPropertyChanged("TeamInfo");
                }
            }

            this.SelectedTeam.AddMember(SelectedMember);
            SetPropertyChanged("AvailableTeams");
            SetPropertyChanged("SelectedTeam");
            SetPropertyChanged("CanAssignToTeam");
            SetPropertyChanged("CanUnassignToTeam");

            MessageBox.Show(string.Format("{0} has been assigned to team: {1}", SelectedMember.Name, SelectedTeam.TeamInfo));
        }

        public bool CanAssignToTeam {
            get {
                return (SelectedMember != null && SelectedTeam != null &&
                  (!SelectedTeam.Members.Contains(SelectedMember)));
            }
        }

        public bool CanUnassignToTeam {
            get {
                return (SelectedMember != null && SelectedTeam != null &&
                  (SelectedMember.BelongsToTeam && SelectedMember.Team == SelectedTeam.Name));
            }
        }


        private MemberModel selectedMember;
        /// <summary>
        /// Gets or sets the Selected Member
        /// </summary>

        public MemberModel SelectedMember {
            get { return this.selectedMember; }
            set {
                if (this.selectedMember != value) {
                    this.selectedMember = value;
                    SetPropertyChanged("CanUnassignToTeam");
                    SetPropertyChanged("CanAssignToTeam");
                    SetPropertyChanged("SelectedMember");
                }
            }
        }

        private TeamModel selectedTeam;
        /// <summary>
        /// Gets or sets the Selected Team from the Dropdown
        /// </summary>

        public TeamModel SelectedTeam {
            get { return this.selectedTeam; }
            set {
                if (this.selectedTeam != value) {
                    this.selectedTeam = value;
                    SetPropertyChanged("CanUnassignToTeam");
                    SetPropertyChanged("CanAssignToTeam");
                    SetPropertyChanged("SelectedTeam");
                }
            }
        }


        private TeamModels availableTeams = new TeamModels();
        /// <summary>
        /// Gets or sets the Available toeams to choose from
        /// </summary>

        public TeamModels AvailableTeams {
            get {
                this.SelectedTeam?.SetPropertyChanged("TeamInfo");
                return this.availableTeams;
            }
            set {
                if (this.availableTeams != value) {
                    this.availableTeams = value;
                    SetPropertyChanged("AvailableTeams");
                }
            }
        }
    }
}

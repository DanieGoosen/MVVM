using MVVM.Training.Base;
using MVVM.Training.Models;
using MVVM.Training.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVM.Training.ViewModels {
    public class MemberViewModel : ModelBase {
        public MemberViewModel() {
            this.AvailableTeams = EventManager.OnGetTeams();

            var members = EventManager.OnGetMembers();
            if (members != null) {
                this.Members = members;
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

        public void AssignToteam(object obj) {
            this.SelectedTeam.AddMember(SelectedMember);
            SetPropertyChanged("AvailableTeams");
            SetPropertyChanged("SelectedTeam");
        }

        public bool CanAssignToTeam {
            get { return (SelectedMember != null && SelectedTeam != null); }
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

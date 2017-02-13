using MVVM.Training.Base;
using MVVM.Training.Models;
using MVVM.Training.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM.Training.ViewModels {
    public class TeamViewModel : ModelBase {
        public TeamViewModel() {
            var teams = EventManager.OnGetTeams();
            if (teams != null) {
                this.Teams = teams;
                this.SelectedTeam = Teams.FirstOrDefault();
            }
        }

        private TeamModel selectedTeam;
        /// <summary>
        /// Gets or sets the Selected Team
        /// </summary>

        public TeamModel SelectedTeam {
            get { return this.selectedTeam; }
            set {
                if (this.selectedTeam != value) {
                    this.selectedTeam = value;
                    SetPropertyChanged("SelectedTeam");
                }
            }
        }



        private TeamModels teams = new TeamModels();
        /// <summary>
        /// Gets or sets the Collection of teams
        /// </summary>

        public TeamModels Teams {
            get { return this.teams; }
            set {
                if (this.teams != value) {
                    this.teams = value;
                    SetPropertyChanged("Teams");
                }
            }
        }

    }
}

using MVVM.Training.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVM.Training.Models {
    public class OrganizationModel : ModelBase {
        public OrganizationModel() {
            this.Id = Guid.NewGuid().ToString();
            this.Teams.Add(new TeamModel("Team A"));
            this.Teams.Add(new TeamModel("Team B"));
            this.Teams.Add(new TeamModel("Team C"));
        }

        public OrganizationModel(string name) {
            this.Name = name;
        }

        #region Properties
        public string Id { get; } = Guid.NewGuid().ToString();

        private string name = "";
        /// <summary>
        /// Gets or sets the Name of the Organization
        /// </summary>

        public string Name {
            get { return this.name; }
            set {
                if (this.name != value) {
                    this.name = value;
                    SetPropertyChanged("Name");
                }
            }
        }

        private TeamModels teams = new TeamModels();
        /// <summary>
        /// Gets or sets the Teams
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

        /// <summary>
        /// Gets or sets the AMount of teams in this organization
        /// </summary>

        public int TeamCount {
            get { return this.Teams.Count; }
        }

        /// <summary>
        /// Gets or sets the AMount of Members
        /// </summary>

        public int MemberCount {
            get {
                var count = 0;
                foreach (var team in Teams) {
                    count += team.Members.Count;
                }
                return count;
            }
        } 
        #endregion

        public override string ToString() {
            return base.ToString();
        }
    }

    public class OrganizationModels : ObservableCollection<OrganizationModel> {
        public override string ToString() {
            return string.Format("{0} Organization{1}", this.Count, this.Count == 1 ? "" : "s");
        }
    }

}

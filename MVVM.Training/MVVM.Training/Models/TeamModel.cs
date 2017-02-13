using MVVM.Training.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVM.Training.Models {
    public class TeamModel : ModelBase {
        public TeamModel() {
            SetPropertyChanged("MemberCount");
        }

        public TeamModel(string name) {
            this.name = name;
        }

        public void AddMember(MemberModel member) {
            if (!this.Members.Contains(member)) {
                this.Members.Add(member);
                member.SetTeam(this.Name);

                this.SetPropertyChanged("MemberCount");
            }
        }

        public void RemoveMember(MemberModel member) {
            this.Members.Remove(member);
        }


        private string name = "";
        /// <summary>
        /// Gets or sets the Team Name
        /// </summary>

        public string Name {
            get { return this.name; }
            set {
                if (this.name != value) {
                    this.name = value;
                    SetPropertyChanged("TeamInfo");
                    SetPropertyChanged("Name");
                }
            }
        }

        private MemberModels members = new MemberModels();
        /// <summary>
        /// Gets or sets the Members of the Team
        /// </summary>

        public MemberModels Members {
            get { return this.members; }
            set {
                if (this.members != value) {
                    this.members = value;
                    SetPropertyChanged("TeamInfo");
                    SetPropertyChanged("Members");
                }
            }
        }

        private MemberModel teamLeader = new MemberModel();
        /// <summary>
        /// Gets or sets the Team Leader member
        /// </summary>

        public MemberModel TeamLeader {
            get { return this.teamLeader; }
            set {
                if (this.teamLeader != value) {
                    this.teamLeader = value;
                    SetPropertyChanged("TeamLeader");
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the Member Count for this team
        /// </summary>

        public int MemberCount {
            get { return this.Members.Count; }
        }

        
        /// <summary>
        /// Gets or sets the information label for the Team
        /// </summary>

        public string TeamInfo {
            get { return string.Format("{0}, {1} Member{2}", Name, Members.Count, Members.Count == 1 ? "" : "s"); }
        }



        public override string ToString() {
            return base.ToString();
        }
    }

    public class TeamModels : ObservableCollection<TeamModel> {
        public override string ToString() {
            return string.Format("{0} Team{1}", this.Count, this.Count == 1 ? "" : "s");
        }
    }
}

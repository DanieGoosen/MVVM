using MVVM.Training.Base;
using MVVM.Training.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVM.Training.Models {
    public class MemberModel : ModelBase {
        public MemberModel() {
            this.Id = Guid.NewGuid().ToString();
        }

        public MemberModel(string name, string lastname, Gender gender) : this() {
            this.Name = name;
            this.Lastname = lastname;
            this.Gender = gender;
        }

        public string Id { get; } = Guid.NewGuid().ToString();

        internal void SetTeam(string name) {
            this.Team = name;
            this.BelongsToTeam = name != null || name != "";
        }

        private string name = "";
        /// <summary>
        /// Gets or sets the name of the member
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

        private string lastname = "";
        /// <summary>
        /// Gets or sets the l;ast nameof the Member
        /// </summary>

        public string Lastname {
            get { return this.lastname; }
            set {
                if (this.lastname != value) {
                    this.lastname = value;
                    SetPropertyChanged("Lastname");
                }
            }
        }

        private Gender gender = Gender.Unspecified;
        /// <summary>
        /// Gets or sets the Gender of the Member
        /// </summary>

        public Gender Gender {
            get { return this.gender; }
            set {
                if (this.gender != value) {
                    this.gender = value;
                    SetPropertyChanged("Gender");
                }
            }
        }

        private bool belongsToTeam = false;
        /// <summary>
        /// Gets or sets the whether the member belongs to a team or not
        /// </summary>

        public bool BelongsToTeam { 
            get { return this.belongsToTeam; }
            set {
                if (this.belongsToTeam != value) {
                    this.belongsToTeam = value;
                    SetPropertyChanged("BelongsToTeam");
                }
            }
        }

        public string Team { get; set; }

        public override string ToString() {
            return string.Format("{0}, {1} ({2})", Lastname, Name, Gender);
        }
    }

    public class MemberModels : ObservableCollection<MemberModel> {
        public override string ToString() {
            return string.Format("{0} Member{1}", this.Count, this.Count == 1 ? "" : "s");
        }
    }
}

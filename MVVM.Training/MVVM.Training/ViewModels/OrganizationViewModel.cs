using MVVM.Training.Base;
using MVVM.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVM.Training.ViewModels {
    public class OrganizationViewModel : ModelBase {
        #region Constructors
        public OrganizationViewModel() {
            addTestModels();
            this.SelectedOrganization = Organizations.FirstOrDefault();
        }

        private void addTestModels() {
            Organizations.Add(new OrganizationModel("Test 1"));
            Organizations.Add(new OrganizationModel("Test 2"));
            Organizations.Add(new OrganizationModel("Test 3"));
            Organizations.Add(new OrganizationModel("Test 4"));
        }
        #endregion

        #region Properties

        private OrganizationModel selectedOrganization;

        public OrganizationModel SelectedOrganization {
            get { return this.selectedOrganization; }
            set {
                if (this.selectedOrganization != value) {
                    this.selectedOrganization = value;
                    SetPropertyChanged("CanRemove");
                    SetPropertyChanged("SelectedOrganization");
                }
            }
        }

        private OrganizationModels organizations = new OrganizationModels();
        /// <summary>
        /// Gets or sets the Collection of organizations that will be managed through the application.
        /// </summary>

        public OrganizationModels Organizations {
            get { return this.organizations; }
            set {
                if (this.organizations != value) {
                    this.organizations = value;
                    SetPropertyChanged("Organizations");
                }
            }
        }

        public bool CanRemove {
            get { return this.SelectedOrganization != null; }
        }
        
        #endregion

        #region Commands
        
        private ICommand _AddOrganizationCommand;
        public ICommand AddOrganizationCommand {
            get {
                if (_AddOrganizationCommand == null) {
                    _AddOrganizationCommand = CreateCommand(AddOrganization);
                }
                return _AddOrganizationCommand;
            }
        }

        private ICommand _RemoveOrganizationCommand;
        public ICommand RemoveOrganizationCommand {
            get {
                if (_RemoveOrganizationCommand == null) {
                    _RemoveOrganizationCommand = CreateCommand(RemoveOrganization);
                }
                return _RemoveOrganizationCommand;
            }
        }

        public void RemoveOrganization(object obj) {
            var index = Organizations.IndexOf(SelectedOrganization);
            this.Organizations.Remove(SelectedOrganization);
            // Re-select the last organization
            //this.SelectedOrganization = this.Organizations[index] ?? null;
        }
        
        #endregion

        #region Methods

        public void AddOrganization(object obj) {
            var newOrganization = new OrganizationModel();
            this.SelectedOrganization = newOrganization;
            this.Organizations.Add(newOrganization);
        }

        #endregion
    }
}

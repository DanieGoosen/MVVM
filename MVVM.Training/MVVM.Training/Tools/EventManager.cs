using MVVM.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM.Training.Tools {
    public class EventManager {
        public static Func<MemberModels> GetMembers;
        public static MemberModels OnGetMembers() {
            return GetMembers?.Invoke();
        }

        public static Func<TeamModels> GetTeams;
        public static TeamModels OnGetTeams() {
            return GetTeams?.Invoke();
        }
    }


}

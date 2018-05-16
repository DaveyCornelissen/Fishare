using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Fishare.Model;

namespace Fishare.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileInfoViewModel ProfileInfoViewModel { get; set; }

        public ProfileSettingsViewModel ProfileSettingsViewModel { get; set; }

        public ProfileFriendsViewModal ProfileFriendsViewModal { get; set; }
    }
}

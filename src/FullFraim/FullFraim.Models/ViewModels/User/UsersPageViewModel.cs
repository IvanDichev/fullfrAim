using FullFraim.Models.ViewModels.Dashboard;
using System.Collections.Generic;

namespace FullFraim.Models.ViewModels.User
{
    public class UsersPageViewModel
    {
        public string sorting { get; set; } = string.Empty;
        public List<PointsTillNextViewModel> Model { get; set; }
    }
}

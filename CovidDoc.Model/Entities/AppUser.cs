using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidDoc.Model
{
    public partial class AppUser
    {
        public bool IsAdmin() => Roles.Any(x => string.Equals(x.Code, AppRoleNames.Admin));
    }
}

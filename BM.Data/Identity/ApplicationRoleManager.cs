using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BM.Data.Identity
{
    public class ApplicationRoleManager : RoleManager<AppRole>
    {
        public ApplicationRoleManager(RoleStore<AppRole> store)
                    : base(store)
        { }
    }
}

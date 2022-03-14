using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Identity
{
    public class ApplicationUserRole: IdentityUserRole<string>
    {
        //it needs to have a pk of type string as mandatory
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }

    }
}

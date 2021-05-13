using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PhotoContest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoContest.Data
{
    public class PCDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {

    }
}

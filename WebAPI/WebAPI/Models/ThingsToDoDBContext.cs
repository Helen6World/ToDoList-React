using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ThingsToDoDBContext:DbContext
    {
        public ThingsToDoDBContext(DbContextOptions<ThingsToDoDBContext> options):base(options)
        {

        }
        public DbSet<ThingToDo> ThingsToDo { get; set; }
     }
}

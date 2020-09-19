using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EvalRaulClaros.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConection")
        {

        }

        public System.Data.Entity.DbSet<EvalRaulClaros.Models.EvalRaulClaros> EvalRaulClaros { get; set; }
    }
}
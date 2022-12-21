﻿using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.DataAccessLayer
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("DBConnection") { }

        public DbSet<Student> students { get; set; }
    }
}

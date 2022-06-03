using Microsoft.EntityFrameworkCore;
using SampleProject.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Data.DataConnection
{
    public class TeacherContext: DbContext
    {
        public TeacherContext(DbContextOptions<TeacherContext> options): base(options)
        {

        }

        public DbSet<TeacherModel> teacherModel { get; set; }

    }
}

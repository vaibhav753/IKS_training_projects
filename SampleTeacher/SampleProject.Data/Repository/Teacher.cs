using SampleProject.Data.DataConnection;
using SampleProject.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleProject.Data.Repository
{
    public class Teacher : ITeacher
    {
        TeacherContext _teacherDbContext;

        public Teacher(TeacherContext teacherContext)
        {
            _teacherDbContext = teacherContext;
        }
        public string AddTeacher(TeacherModel teacher)
        {
            _teacherDbContext.teacherModel.Add(teacher);
            _teacherDbContext.SaveChanges();
            return "Teacher Added Successfully...!!";
        }

        public List<TeacherModel> FetchAllTeachers()
        {
            List<TeacherModel> teachers = _teacherDbContext.teacherModel.ToList();
            return teachers;
        }
    }
}

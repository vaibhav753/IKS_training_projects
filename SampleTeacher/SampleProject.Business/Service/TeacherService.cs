using SampleProject.Data.Repository;
using SampleProject.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Business.Service
{
    public class TeacherService
    {
        ITeacher _teacher;

        public TeacherService(ITeacher teacher)
        {
            _teacher = teacher;
        }

        public string AddTeacher(TeacherModel teacherModel)
        {
            return _teacher.AddTeacher(teacherModel);
        }

        public List<TeacherModel> fetchTeachers()
        {
            return _teacher.FetchAllTeachers();  
        }
    }
}

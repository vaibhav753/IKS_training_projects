using SampleProject.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Data.Repository
{
    public interface ITeacher
    {
        List<TeacherModel> FetchAllTeachers();

        string AddTeacher(TeacherModel teacher);
    }
}

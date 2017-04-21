namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string name)
            :base(name)
        {
            this.Name = name;
            this.Type = "OffsiteCourse";
            this.TeacherName = null;
            this.Students = new List<string>();
            this.Location = null;
            this.LocationType = "Town";
        }

        public OffsiteCourse(string courseName, string teacherName)
            :base(courseName, teacherName)
        {
            this.Name = courseName;
            this.Type = "OffsiteCourse";
            this.TeacherName = teacherName;
            this.Students = new List<string>();
            this.Location = null;
            this.LocationType = "Town";
        }

        public OffsiteCourse(string courseName, string teacherName, string location, IList<string> students)
            :base(courseName, teacherName, location, students)
        {
            this.Name = courseName;
            this.Type = "OffsiteCourse";
            this.TeacherName = teacherName;
            this.Students = students;
            this.Location = location;
            this.LocationType = "Town";
        }
    }
}

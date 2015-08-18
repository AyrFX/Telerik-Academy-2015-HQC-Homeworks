namespace InheritanceAndPolymorphism
{
	using System;
	using System.Collections.Generic;

	public abstract class Course
	{
		public Course(string courseName)
			: this(courseName, null)
		{
		}
		
		public Course(string courseName, string teacherName)
			: this(courseName, teacherName, new List<string>())
		{
		}
		
		public Course(string courseName, string teacherName, IList<string> students)
		{
			this.Name = courseName;
			this.TeacherName = teacherName;
			this.Students = students;
		}
		
		public string Name { get; set; }

		public string TeacherName { get; set; }

		public IList<string> Students { get; set; }
		
		public abstract override string ToString();
		
		protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
	}
}

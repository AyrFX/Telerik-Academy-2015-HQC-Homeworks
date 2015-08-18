namespace SchoolDemo
{
    using System;
    using System.Collections.Generic;
    
    public class Course
    {
        private List<Student> students;

        public Course(List<Student> students)
        {
            this.Students = students;
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value.Count < 1 || value.Count > 30)
                {
                    throw new ArgumentOutOfRangeException("The number of students int each ciurse must be between 1 and 30!");
                }

                this.students = value;
            }
        }

        public void Join(Student student)
        {
            if (this.Students.Count == 30)
            {
                throw new OverflowException("The number of students int each ciurse must be between 1 and 30!");
            }

            if (student == null)
            {
                throw new ArgumentNullException("The stydent for joining the course can't be null!");
            }

            this.students.Add(student);
        }

        public void Leave(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student to leave can't be null!");
            }

            this.students.Remove(student);
        }
    }
}

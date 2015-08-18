namespace SchoolDemo
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private List<Course> coursesList;

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("The course to add can't be null!");
            }

            this.coursesList.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("The course to remove can't be null!");
            }

            this.coursesList.Remove(course);
        }
    }
}

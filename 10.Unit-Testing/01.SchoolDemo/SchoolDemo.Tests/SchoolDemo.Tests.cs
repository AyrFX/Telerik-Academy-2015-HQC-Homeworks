namespace SchoolDemo.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolDemo;

    [TestClass]
    public class SchooldemoTests
    {
        [TestMethod]
        public void Test_StudentsShouldHaveUniqueID()
        {
            Student firstStudent = new Student("Pesho");
            Student secondStudent = new Student("Gosho");
            Assert.AreNotEqual(firstStudent.Id, secondStudent.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_StudentNameShouldntBeNull()
        {
            Student firstStudent = new Student(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_StudentNameShouldntBeEmpty()
        {
            Student firstStudent = new Student(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_CourseCantBeCreatedWithEmptyListOfStudents()
        {
            Course someCourse = new Course(new List<Student>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_CourseCantHaveMoreThanThirtyStudents()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i <= 30; i++)
            {
                students.Add(new Student("Student" + i));
            }

            Course someCourse = new Course(students);
        }

        [TestMethod]
        public void Test_CourseCanHaveStudentsBetweenOneAndThirty()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i <= 10; i++)
            {
                students.Add(new Student("Student" + i));
            }

            Course someCourse = new Course(students);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Test_ThirtyFirstStudentCantJoinTheCourse()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 30; i++)
            {
                students.Add(new Student("Student" + i));
            }

            Course someCourse = new Course(students);
            someCourse.Join(new Student("Pesho"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_NullStudentCantJoinTheCourse()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student("Student" + i));
            }

            Course someCourse = new Course(students);
            someCourse.Join(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_NullStudentCantLeaveTheCourse()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student("Student" + i));
            }

            Course someCourse = new Course(students);
            someCourse.Leave(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_NullCourseCantBeAdded()
        {
            School someSchool = new School();
            someSchool.AddCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_NullCourseCantBeRemoved()
        {
            School someSchool = new School();
            someSchool.RemoveCourse(null);
        }
    }
}

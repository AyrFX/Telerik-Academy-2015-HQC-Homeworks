namespace SchoolDemo
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private static int currentId = 10000;

        private string name;

        private int id;

        public Student(string name)
        {
            this.Name = name;
            this.Id = currentId;
            currentId++;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of the student can't be null or empty string!");
                }

                this.name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (10000 > value || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("The ID if student can be between 10000 and 99999!");
                }

                this.id = value;
            }
        }
    }
}

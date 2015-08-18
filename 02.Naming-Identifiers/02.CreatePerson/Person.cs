namespace PersonGenerator
{
    using System;

    public class PersonGenerator
    {
        internal enum PersonGender
        {
            male,
            female
        }

        public void CreatePerson(int age)
        {
            Person newPerson = new Person();
            newPerson.Age = age;
            if (age % 2 == 0)
            {
                newPerson.Name = "Mr.";
                newPerson.Gender = PersonGender.male;
            }
            else
            {
                newPerson.Name = "Mrs.";
                newPerson.Gender = PersonGender.female;
            }
        }

        public class Person
        {
            public PersonGender Gender { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}

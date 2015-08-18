namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate, secondDate;

            if (this.OtherInfo == string.Empty || other.OtherInfo == string.Empty)
            {
                throw new ArgumentException("There is no info for some of the students!");
            }

            try
            {
                firstDate = DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            }
            catch (FormatException)
            {
                throw new ArgumentException("The info for the stdent doesn\'t contain birthdate in valid format!");
            }

            try
            {
                secondDate = DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));
            }
            catch (FormatException)
            {
                throw new ArgumentException("The info for the other stdent doesn\'t contain birthdate in valid format!");
            }

            bool isOlder = firstDate < secondDate;
            return isOlder;
        }
    }
}

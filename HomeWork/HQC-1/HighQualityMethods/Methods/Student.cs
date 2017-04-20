namespace Methods
{
    using System;

    public class Student
    {
        private string firstName;

        private string lastName;

        private DateTime dateOfBirth;

        private string info;

        public Student(string firstName, string lastName, DateTime dateOfBirth, string info = "")
            : this(firstName, lastName, info)
        {
            this.DateOfBirth = dateOfBirth;
        }

        public Student(string firstName, string lastName, string dateOfBirth, string info = "")
            : this(firstName, lastName, info)
        {
            this.DateOfBirth = this.DateTimeParse(dateOfBirth);
        }

        private Student(string firstname, string lastNamem, string info)
        {
            this.FirstName = this.firstName;
            this.LastName = this.lastName;
            this.Info = this.info;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("FirstName");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("LastName");
                }

                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            private set
            {
                if (this.IsValidDateOfBirth(value, DateTime.Today))
                {
                    this.dateOfBirth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("DateOfBirth");
                }
            }
        }

        public string Info
        {
            get
            {
                return this.info;
            }

            set
            {
                this.info = value == null ? string.Empty : value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            return this.dateOfBirth > other.dateOfBirth;
        }

        private DateTime DateTimeParse(string date)
        {
            DateTime parsedDate;
            bool success = DateTime.TryParse(date, out parsedDate);

            if (!success)
            {
                throw new ArgumentException("DateOfBirth");
            }

            return parsedDate;
        }

        private bool IsValidDateOfBirth(DateTime dateOfBirth, DateTime now)
        {
            int age = now.Year - dateOfBirth.Year;

            if (now < dateOfBirth.AddYears(age))
            {
                age--;
            }

            if (GlobalConstants.MinmumStudentAge <= age && age <= GlobalConstants.MaximumStudentAge)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
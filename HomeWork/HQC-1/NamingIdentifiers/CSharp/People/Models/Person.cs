namespace People.Models
{
    using Contracts;
    using Enums;

    public class Person : IPerson
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public GenderType Gender { get; set; }

        public IPerson MakePerson(int age)
        {
            IPerson person = new Person();
            person.Age = age;

            if (age % 2 == 0)
            {
                person.Name = "George";
                person.Gender = GenderType.Male;
            }
            else
            {
                person.Name = "Janet";
                person.Gender = GenderType.Female;
            }

            return person;
        }
    }
}
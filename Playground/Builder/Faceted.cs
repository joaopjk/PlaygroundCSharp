namespace Builder
{
    public class PersonFC
    {
        public string StreetAddress, Postcode, City;
        public string CompanyName, Position;
        public int AnnualIncome;
    }

    public class PersonBuilderFC
    {
        protected PersonFC person = new();
        public PersonJobBuilderFC Worker => new PersonJobBuilderFC(person);
    }

    public class PersonJobBuilderFC : PersonBuilderFC
    {
        public PersonJobBuilderFC(PersonFC person)
        {
            this.person = person;
    }

        public PersonJobBuilderFC At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilderFC AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilderFC Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }
}

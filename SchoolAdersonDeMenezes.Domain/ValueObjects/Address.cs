namespace SchoolAdersonDeMenezes.Domain.ValueObjects
{
    /// <summary>
    /// Object responsible for modeling Address
    /// </summary>
    public class Address
    {
        public string Street { get; private set;}
        public string City { get; private set;}
        public string State { get; private set;}    
        public string Number { get; private set;}

        public Address(string street, string city, string state, string number)
        {
            Street = street;
            City = city;
            State = state;
            Number = number;
        }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   Street == address.Street &&
                   City == address.City &&
                   State == address.State &&
                   Number == address.Number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, City, State, Number);
        }
    }
}

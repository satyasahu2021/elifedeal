namespace Core.Entities.OrderAggregate
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string? firstName, string? lastName, string? phoneNo,  string? street, string? city, string? state, string? zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNo = phoneNo;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string? FirstName { get; set;}

         public string? LastName { get; set;}

         public string? PhoneNo { get; set; }

         public string? Street { get; set;}

         public string? City { get; set;}

         public string? State { get; set;}

         public string? ZipCode { get; set;}
         
    }
}
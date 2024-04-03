namespace ClinicManager.Core.ValueObjects
{
    public record Address
    {
        public Address()
        {

        }

        public Address(string street, string city, string state, string zipCode, string houseNumber, string?
            housingComplement)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            HouseNumber = houseNumber;
            HousingComplement = housingComplement;
        }

        public string Street { get; init; }

        public string City { get; init; }

        public string State { get; init; }

        public string ZipCode { get; init; }

        public string HouseNumber { get; init; }

        public string? HousingComplement { get; init; }

        public override string ToString()
        {
            return $@"Street: {Street} - {HouseNumber} {(HousingComplement is not null ? " - " + HousingComplement : "")},
                     City: {City}, State: {State}, ZipCode: {ZipCode}";
        }
    }
}

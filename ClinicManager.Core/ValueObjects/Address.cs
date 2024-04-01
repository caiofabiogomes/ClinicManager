namespace ClinicManager.Core.ValueObjects
{
    public record Address(string Street, string City, string State, string ZipCode, string HouseNumber, string?
    HousingComplement)
    {
        public override string ToString()
        {
            return $@"Street: {Street} - {HouseNumber} {(HousingComplement is not null ? " - " + HousingComplement : "")},
                     City: {City}, State: {State}, ZipCode: {ZipCode}";
        }
    }
}

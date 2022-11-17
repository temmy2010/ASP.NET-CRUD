namespace WalletPlus_Inc.Web.Data.Entities
{
    public class Customer : BaseEntity<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public GenderEnum Gender { get; set; }

        public string MaritalStatus { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }
    }
}

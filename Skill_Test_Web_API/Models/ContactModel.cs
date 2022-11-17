namespace _Skill_Test_Web_API.Models
{
    public class Address
    {
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ID { get; set; }
        public string Region { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public int StatusCode { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BusinessRelationID { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public string AddressLine1 { get; set; }
        public BusinessRelation BusinessRelation { get; set; }
        public CustomValues CustomValues { get; set; }
    }

    public class BankAccount
    {
        public int CompanySettingsID { get; set; }
        public string BankAccountType { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ID { get; set; }
        public string Label { get; set; }
        public int BankAccountSettingsID { get; set; }
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public bool Locked { get; set; }
        public int StatusCode { get; set; }
        public string IBAN { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BusinessRelationID { get; set; }
        public string UpdatedBy { get; set; }
        public int BankID { get; set; }
        public string CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public BankAccountSettings BankAccountSettings { get; set; }
        public CustomValues CustomValues { get; set; }
    }

    public class BankAccountSettings
    {
        public DateTime UpdatedAt { get; set; }
        public int ID { get; set; }
        public bool IsTaxAccount { get; set; }
        public DateTime BalanceAvailableUpdatedAt { get; set; }
        public int StatusCode { get; set; }
        public int IntegrationStatus { get; set; }
        public DateTime BalanceBookedUpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CurrencyCode { get; set; }
        public double BalanceAvailable { get; set; }
        public double BalanceBooked { get; set; }
        public string UpdatedBy { get; set; }
        public string IntegrationSettings { get; set; }
        public string CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public CustomValues CustomValues { get; set; }
    }

    public class BusinessRelation
    {
        public int InvoiceAddressID { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ID { get; set; }
        public int DefaultBankAccountID { get; set; }
        public int StatusCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string Name { get; set; }
        public int DefaultPhoneID { get; set; }
        public int DefaultEmailID { get; set; }
        public int ShippingAddressID { get; set; }
        public string CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public int DefaultContactID { get; set; }
        public Contact DefaultContact { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
        public Address InvoiceAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public Phone DefaultPhone { get; set; }
        public Email DefaultEmail { get; set; }
        public BankAccount DefaultBankAccount { get; set; }
        public CustomValues CustomValues { get; set; }
    }

    public class Contact
    {
        public int InfoID { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ID { get; set; }
        public int ParentBusinessRelationID { get; set; }
        public int StatusCode { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public BusinessRelation ParentBusinessRelation { get; set; }
        public BusinessRelation Info { get; set; }
        public CustomValues CustomValues { get; set; }
    }

    public class CustomValues
    {
    }

    public class Email
    {
        public string EmailAddress { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int StatusCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BusinessRelationID { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public CustomValues CustomValues { get; set; }
    }

    public class Phone
    {
        public string CountryCode { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int StatusCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BusinessRelationID { get; set; }
        public string UpdatedBy { get; set; }
        public string Number { get; set; }
        public string CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public CustomValues CustomValues { get; set; }
    }

}
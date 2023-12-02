using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    // Represents a contact entity in the application
    public class Contact
    {
        // Unique identifier for each contact
        public int ContactId { get; set; }

        // ID of the owner of the contact (can be null)
        public string? OwnerID { get; set; }

        // Name of the contact
        public string? Name { get; set; }

        // Address details of the contact
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }

        // Email address of the contact with data type validation
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        // Status of the contact: Submitted, Approved, Rejected
        public ContactStatus Status { get; set; }
    }

    // Enum representing the status of a contact
    public enum ContactStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}

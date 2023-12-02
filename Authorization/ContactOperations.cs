using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ContactManager.Authorization
{
    // Static class defining contact-related operations for authorization
    public static class ContactOperations
    {
        // OperationAuthorizationRequirements for various contact operations
        public static OperationAuthorizationRequirement Create =
            new OperationAuthorizationRequirement { Name = Constants.CreateOperationName };
        public static OperationAuthorizationRequirement Read =
            new OperationAuthorizationRequirement { Name = Constants.ReadOperationName };
        public static OperationAuthorizationRequirement Update =
            new OperationAuthorizationRequirement { Name = Constants.UpdateOperationName };
        public static OperationAuthorizationRequirement Delete =
            new OperationAuthorizationRequirement { Name = Constants.DeleteOperationName };
        public static OperationAuthorizationRequirement Approve =
            new OperationAuthorizationRequirement { Name = Constants.ApproveOperationName };
        public static OperationAuthorizationRequirement Reject =
            new OperationAuthorizationRequirement { Name = Constants.RejectOperationName };
    }

    // Constants class holding names and roles for contact-related authorization
    public class Constants
    {
        // Operation names for contact-related actions
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read";
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";
        public static readonly string ApproveOperationName = "Approve";
        public static readonly string RejectOperationName = "Reject";

        // Roles for contact-related authorization
        public static readonly string ContactAdministratorsRole =
            "ContactAdministrators";
        public static readonly string ContactManagersRole = "ContactManagers";
    }
}

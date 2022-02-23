using Microsoft.AspNetCore.Identity;

namespace LonShop.BaseCore.Constants
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() { return new IdentityError { Code = MsgStatusCode.Code1051, Description = $"An unknown failure has occurred." }; }
        public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = MsgStatusCode.Code1052, Description = "Optimistic concurrency failure, object has been modified." }; }
        public override IdentityError RecoveryCodeRedemptionFailed() { return new IdentityError { Code = MsgStatusCode.Code1053, Description = "Recovery code redemption failed." }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = MsgStatusCode.Code1054, Description = "Incorrect password." }; }
        public override IdentityError InvalidToken() { return new IdentityError { Code = MsgStatusCode.Code1055, Description = "Invalid token." }; }
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = MsgStatusCode.Code1056, Description = "A user with this login already exists." }; }
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = MsgStatusCode.Code1057, Description = $"User name '{userName}' is invalid, can only contain letters or digits." }; }
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = MsgStatusCode.Code1058, Description = $"Email '{email}' is invalid." }; }
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = MsgStatusCode.Code1059, Description = $"User Name '{userName}' is already taken." }; }
        public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = MsgStatusCode.Code1060, Description = $"Email '{email}' is already taken." }; }
        public override IdentityError InvalidRoleName(string role) { return new IdentityError { Code = MsgStatusCode.Code1061, Description = $"Role name '{role}' is invalid." }; }
        public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = MsgStatusCode.Code1062, Description = $"Role name '{role}' is already taken." }; }
        public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = MsgStatusCode.Code1063, Description = "User already has a password set." }; }
        public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = MsgStatusCode.Code1064, Description = "Lockout is not enabled for this user." }; }
        public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = MsgStatusCode.Code1065, Description = $"User already in role '{role}'." }; }
        public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = MsgStatusCode.Code1066, Description = $"User is not in role '{role}'." }; }
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = MsgStatusCode.Code1067, Description = $"Passwords must be at least {length} characters." }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = MsgStatusCode.Code1068, Description = "Passwords must have at least one non alphanumeric character." }; }
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = MsgStatusCode.Code1069, Description = "Passwords must have at least one digit ('0'-'9')." }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = MsgStatusCode.Code1070, Description = "Passwords must have at least one lowercase ('a'-'z')." }; }
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = MsgStatusCode.Code1071, Description = "Passwords must have at least one uppercase ('A'-'Z')." }; }
        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars) { return new IdentityError { Code = MsgStatusCode.Code1072, Description = "Passwords must have at least one unique chars." }; }
    }
}

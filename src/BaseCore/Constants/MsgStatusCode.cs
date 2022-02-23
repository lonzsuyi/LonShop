using System.ComponentModel;

namespace LonShop.BaseCore.Constants
{
    public static class MsgStatusCode
    {
        #region Http status code(1~1000)

        /// <summary>
        /// OK.
        /// </summary>
        [Description("OK.")]
        public const string Code200 = "200";

        /// <summary>
        /// Not Modified.
        /// </summary>
        [Description("Not Modified.")]
        public const string Code304 = "304";

        /// <summary>
        /// Bad Request.
        /// </summary>
        [Description("Bad Request.")]
        public const string Code400 = "400";

        /// <summary>
        /// Unauthorized.
        /// </summary>
        [Description("Unauthorized.")]
        public const string Code401 = "401";

        /// <summary>
        /// Not Found.
        /// </summary>
        [Description("Not Found.")]
        public const string Code404 = "404";

        /// <summary>
        /// Request Timeout.
        /// </summary>
        [Description("Request Timeout.")]
        public const string Code408 = "408";

        /// <summary>
        /// Internal Server Error.
        /// </summary>
        [Description("Internal Server Error.")]
        public const string Code500 = "500";

        /// <summary>
        /// Not Implemented.
        /// </summary>
        [Description("Not Implemented.")]
        public const string Code501 = "501";

        /// <summary>
        /// Bad Gateway.
        /// </summary>
        [Description("Bad Gateway.")]
        public const string Code502 = "502";

        /// <summary>
        /// Service Unavailable.
        /// </summary>
        [Description("Service Unavailable.")]
        public const string Code503 = "503";

        /// <summary>
        /// Gateway Timeout.
        /// </summary>
        [Description("Gateway Timeout.")]
        public const string Code504 = "504";

        /// <summary>
        /// HTTP Version Not Supported.
        /// </summary>
        [Description("HTTP Version Not Supported.")]
        public const string Code505 = "505";

        #endregion

        #region User (1001~1100)

        /// <summary>
        /// Invalid sign in attempt.
        /// </summary>
        [Description("Invalid sign in attempt.")]
        public const string Code1001 = "1001";

        /// <summary>
        /// Sign out success.
        /// </summary>
        [Description("Sign out success.")]
        public const string Code1002 = "1002";

        /// <summary>
        /// Sign in timeout or unauthorized.
        /// </summary>
        [Description("Sign in timeout or unauthorized.")]
        public const string Code1003 = "1003";

        /// <summary>
        /// The account was not approved.
        /// </summary>
        [Description("The account was not Enabled.")]
        public const string Code1004 = "1004";

        /// <summary>
        /// Invalid account.
        /// </summary>
        [Description("Invalid account.")]
        public const string Code1005 = "1005";

        /// <summary>
        /// Find password error.
        /// </summary>
        [Description("Find password error.")]
        public const string Code1006 = "1006";

        /// <summary>
        /// Change password error.
        /// </summary>
        [Description("Change password error.")]
        public const string Code1007 = "1007";

        /// <summary>
        /// Change password success.
        /// </summary>
        [Description("Change password success.")]
        public const string Code1008 = "1008";

        /// <summary>
        /// Create user error.
        /// </summary>
        [Description("Create user error.")]
        public const string Code1021 = "1021";

        /// <summary>
        /// Create user success.
        /// </summary>
        [Description("Create user success.")]
        public const string Code1022 = "1022";

        /// <summary>
        /// Update user error.
        /// </summary>
        [Description("Update user error.")]
        public const string Code1023 = "1023";

        /// <summary>
        /// Update user success.
        /// </summary>
        [Description("Update user success.")]
        public const string Code1024 = "1024";

        /// <summary>
        /// An unknown failure has occurred.
        /// </summary>
        [Description("An unknown failure has occurred.")]
        public const string Code1051 = "1051";

        /// <summary>
        /// Optimistic concurrency failure, object has been modified.
        /// </summary>
        [Description("Optimistic concurrency failure, object has been modified.")]
        public const string Code1052 = "1052";

        /// <summary>
        /// Recovery code redemption failed.
        /// </summary>
        [Description("Recovery code redemption failed.")]
        public const string Code1053 = "1053";

        /// <summary>
        /// Incorrect password."
        /// </summary>
        [Description("Incorrect password.")]
        public const string Code1054 = "1054";

        /// <summary>
        /// Invalid token.
        /// </summary>
        [Description("Invalid token.")]
        public const string Code1055 = "1055";

        /// <summary>
        /// A user with this login already exists.
        /// </summary>
        [Description("A user with this login already exists.")]
        public const string Code1056 = "1056";

        /// <summary>
        /// User name is invalid, can only contain letters or digits.
        /// </summary>
        [Description("User name is invalid, can only contain letters or digits.")]
        public const string Code1057 = "1057";

        /// <summary>
        /// Email is invalid.
        /// </summary>
        [Description("Email is invalid.")]
        public const string Code1058 = "1058";

        /// <summary>
        /// User Name is already taken.
        /// </summary>
        [Description("User Name is already taken.")]
        public const string Code1059 = "1059";

        /// <summary>
        /// Email is already taken.
        /// </summary>
        [Description("Email is already taken.")]
        public const string Code1060 = "1060";

        /// <summary>
        /// Role name is invalid.
        /// </summary>
        [Description("Role name is invalid.")]
        public const string Code1061 = "1061";

        /// <summary>
        /// Role name is already taken.
        /// </summary>
        [Description("Role name is already taken.")]
        public const string Code1062 = "1062";

        /// <summary>
        /// User already has a password set.
        /// </summary>
        [Description("User already has a password set.")]
        public const string Code1063 = "1063";

        /// <summary>
        /// Lockout is not enabled for this user.
        /// </summary>
        [Description("Lockout is not enabled for this user.")]
        public const string Code1064 = "1064";

        /// <summary>
        /// User already in role.
        /// </summary>
        [Description("User already in role.")]
        public const string Code1065 = "1065";

        /// <summary>
        /// User is not in role.
        /// </summary>
        [Description("User is not in role.")]
        public const string Code1066 = "1066";

        /// <summary>
        /// Passwords must be at least 6 characters.
        /// </summary>
        [Description("Passwords must be at least 6 characters.")]
        public const string Code1067 = "1067";

        /// <summary>
        /// Passwords must have at least one non alphanumeric character.
        /// </summary>
        [Description("Passwords must have at least one non alphanumeric character.")]
        public const string Code1068 = "1068";

        /// <summary>
        /// Passwords must have at least one digit ('0'-'9').
        /// </summary>
        [Description("Passwords must have at least one digit ('0'-'9').")]
        public const string Code1069 = "1069";

        /// <summary>
        /// Passwords must have at least one lowercase ('a'-'z').
        /// </summary>
        [Description("Passwords must have at least one lowercase ('a'-'z').")]
        public const string Code1070 = "1070";

        /// <summary>
        /// Passwords must have at least one uppercase ('A'-'Z').
        /// </summary>
        [Description("Passwords must have at least one uppercase ('A'-'Z').")]
        public const string Code1071 = "1071";

        /// <summary>
        /// Passwords must have at least one unique chars.
        /// </summary>
        [Description("Passwords must have at least one unique chars.")]
        public const string Code1072 = "1072";

        /// <summary>
        /// User does not exist.
        /// </summary>
        [Description("User does not exist.")]
        public const string Code1073 = "1073";

        /// <summary>
        /// User group does not exist.
        /// </summary>
        [Description("User group does not exist.")]
        public const string Code1074 = "1074";

        /// <summary>
        /// Unauthorized create administratorsRole roles.
        /// </summary>
        [Description("Unauthorized create administratorsRole roles.")]
        public const string Code1075 = "1075";

        /// <summary>
        /// User email exist.
        /// </summary>
        [Description("User email exist.")]
        public const string Code1076 = "1076";

        #endregion

        #region ViewModel validtor code(1101~1300)

        /// <summary>
        /// Parameter required and not empty.
        /// </summary>
        [Description("Parameter required and not empty.")]
        public const string Code1101 = "1101";

        /// <summary>
        /// Parameter required and allow empty.
        /// </summary>
        [Description("Parameter required and allow empty.")]
        public const string Code1102 = "1102";

        /// <summary>
        /// Invalid string length.
        /// </summary>
        [Description("Invalid string length.")]
        public const string Code1103 = "1103";

        /// <summary>
        /// Invalid enum type.
        /// </summary>
        [Description("Invalid enum type.")]
        public const string Code1104 = "1104";

        /// <summary>
        /// Invalid Email format.
        /// </summary>
        [Description("Invalid Email format.")]
        public const string Code1201 = "1201";

        /// <summary>
        /// Invalid password format.
        /// </summary>
        [Description("Invalid password format.")]
        public const string Code1202 = "1202";

        /// <summary>
        /// Confirm password do not match.
        /// </summary>
        [Description("Confirm password do not match.")]
        public const string Code1203 = "1203";

        /// <summary>
        /// Invalid date time format.
        /// </summary>
        [Description("Invalid date time format.")]
        public const string Code1204 = "1204";

        /// <summary>
        /// Invalid user roles.
        /// </summary>
        [Description("Invalid user roles.")]
        public const string Code1206 = "1206";

        /// <summary>
        /// Out of file size.
        /// </summary>
        [Description("Out of file size.")]
        public const string Code1209 = "1209";

        /// <summary>
        /// List count must greater than 0.
        /// </summary>
        [Description("List count must greater than 0.")]
        public const string Code1210 = "1210";

        #endregion

        #region  WebSocket code(1301~1320)

        /// <summary>
        /// Parameter required and allow empty.
        /// </summary>
        [Description("Websocket handshake success.")]
        public const string Code1301 = "1301";

        /// <summary>
        /// Websocket handle message error.
        /// </summary>
        [Description("Websocket handle message error.")]
        public const string Code1302 = "1302";

        /// <summary>
        /// Websocket upload type must be block binary.
        /// </summary>
        [Description("Websocket upload type must be block binary.")]
        public const string Code1303 = "1303";

        /// <summary>
        /// Websocket not WsType.
        /// </summary>
        [Description("Websocket not WsType.")]
        public const string Code1304 = "1304";

        /// <summary>
        /// Websocket upload file error.
        /// </summary>
        [Description("Websocket upload file error.")]
        public const string Code1305 = "1305";

        /// <summary>
        /// Websocket upload file info error.
        /// </summary>
        [Description("Websocket upload file info error.")]
        public const string Code1306 = "1306";

        /// <summary>
        /// Websocket upload file size error.
        /// </summary>
        [Description("Websocket upload file size error.")]
        public const string Code1307 = "1307";

        /// <summary>
        /// Websocket upload file type error.
        /// </summary>
        [Description("Websocket upload file type error.")]
        public const string Code1308 = "1308";

        #endregion

        /// <summary>
        /// Websocket upload file type error.
        /// </summary>
        [Description("Quantity must be bigger than 0.")]
        public const string Code1401 = "13401";

    }
}

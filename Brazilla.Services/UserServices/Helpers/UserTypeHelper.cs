﻿using Brazilla.Database.Enums;

namespace Brazilla.Services.UserServices.Helpers
{
    public class UserTypeHelper
    {
        public static UserTypes? GetUserTypeAsEnum(string? type)
        {
            switch(type?.ToLower())
            {
                case "admin":
                    {
                        return UserTypes.Admin;
                    }
                case "user":
                case "client":
                    {
                        return UserTypes.Client;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}

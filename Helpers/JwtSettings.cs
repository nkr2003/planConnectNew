namespace EventManagement.Helpers
{
    public class JwtSettings
    {
        public string Key { get; set; } // Secret key for signing JWTs
        public string Issuer { get; set; } // Issuer of the JWT
        public string Audience { get; set; } // Audience for the JWT
        public int AccessTokenExpirationMinutes { get; set; } // Token expiration time in minutes
        public int RefreshTokenExpirationDays { get; set; } // Refresh token expiration time in days
    }
}

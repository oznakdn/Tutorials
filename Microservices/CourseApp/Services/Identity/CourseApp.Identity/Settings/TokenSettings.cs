namespace CourseApp.Identity.Settings
{
    public class TokenSettings
    {
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public string SecurityKey { get; set; } = default!;

    }
}

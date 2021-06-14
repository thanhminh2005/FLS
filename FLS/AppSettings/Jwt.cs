namespace FLS.AppSettings
{
    public class Jwt
    {
        public string SecretKey { get; set; }
        public int ExprireMinutes { get; set; }
    }
}
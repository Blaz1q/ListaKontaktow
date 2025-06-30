public static class Validate
{
    public static bool IsStrongPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false; //jeżeli pusty to jest niepoprawny

        bool hasUpper = password.Any(char.IsUpper); //czy ma duża litere
        bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch)); //czy posiada liczbe
        bool hasMinLength = password.Length >= 8; //czy ma więcej niż 8 znaków

        return hasUpper && hasSpecial && hasMinLength;
    }
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false; //czy jest pusty

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address.Equals(email);
        }
        catch
        {
            return false;
        }
    }
}
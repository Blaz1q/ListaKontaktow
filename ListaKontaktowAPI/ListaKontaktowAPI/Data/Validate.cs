namespace ListaKontaktowAPI.Data
{
    public static class Validate
    {
        public static bool IsStrongPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            bool hasUpper = password.Any(char.IsUpper);
            bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));
            bool hasMinLength = password.Length >= 8;

            return hasUpper && hasSpecial && hasMinLength;
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

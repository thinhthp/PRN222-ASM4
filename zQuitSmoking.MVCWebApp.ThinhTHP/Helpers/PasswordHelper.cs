using BCrypt.Net;
using Microsoft.CodeAnalysis.Scripting;

public static class PasswordHelper
{
    public static string HashPassword(string password)
    {
        // Update the method to use the correct namespace and method
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Update the method to use the correct namespace and method
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}

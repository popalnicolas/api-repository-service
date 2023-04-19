using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace PopApp.dk.DataAccess.Models;

[Table(name:"accounts")]
public class Account
{
    [NotMapped]
    private string _password = string.Empty;
    [NotMapped]
    private string _username = string.Empty;

    [Key] [Column("account_id")] public long AccountId { get; set; }

    public string Username
    {
        get => _username; 
        set => _username = value.ToLower();
    }
    
    public string Password
    {
        get => _password;
        set => _password = ComputeSHA256($"{Username}:{value}");
    }

    public string Email { get; set; } = string.Empty;

    private string ComputeSHA256(string password)
    {
        var encrypted = string.Empty;

        // Initialize a SHA256 hash object
        using (var sha256 = SHA256.Create())
        {
            // Compute the hash of the given string
            var hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert the byte array to string format
            foreach (var b in hashValue) encrypted += $"{b:X2}";
        }

        return encrypted;
    }
}
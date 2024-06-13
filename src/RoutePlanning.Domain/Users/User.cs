using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Orders;

namespace RoutePlanning.Domain.Users;

[DebuggerDisplay("{Username}")]
public sealed class User : AggregateRoot<User>
{
    public User(string username, string passwordHash, string email)
    {
        Username = username;
        PasswordHash = passwordHash;
        Email = email;
    }

    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    private readonly List<Order> orders = [];
    public IReadOnlyCollection<Order> Orders => orders.AsReadOnly();

    public static string ComputePasswordHash(string password) => Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
}

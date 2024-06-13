using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Delivery;

namespace RoutePlanning.Domain.Users;

[DebuggerDisplay("{Username}")]
public sealed class User : AggregateRoot<User>
{
    public User(string username, string passwordHash)
    {
        Username = username;
        PasswordHash = passwordHash;
        Orders = new List<Order>();
    }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public List<Order> Orders { get; }

    public void AddOrder(Order order)
    {
        Orders.Add(order);
    }

    public static string ComputePasswordHash(string password) => Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
}

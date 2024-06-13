using Netcompany.Net.Cqs.Commands;

namespace RoutePlanning.Application.Locations.Commands.GetConnections;
public sealed record GetConnections(DateTime dateFrom, DateTime dateTo, int weight, string freightType) : ICommand;

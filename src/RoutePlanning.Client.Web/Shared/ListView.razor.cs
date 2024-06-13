using MediatR;
using Microsoft.AspNetCore.Components;
using RoutePlanning.Application.Locations.Queries.SelectableLocationList;

namespace RoutePlanning.Client.Web.Shared;

public sealed partial class ListView
{
    private bool ShowModal { get; set; } = false;

    [Inject]
    private IMediator Mediator { get; set; } = default!;
    private void OnClickShowModal()
    {
        ShowModal = !ShowModal;
    }
}

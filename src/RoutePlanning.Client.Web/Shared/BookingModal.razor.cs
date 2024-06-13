using Microsoft.AspNetCore.Components;
using RoutePlanning.Application.Locations.Queries.SelectableLocationList;

namespace RoutePlanning.Client.Web.Shared;

public sealed partial class BookingModal
{
    [Parameter] 
    public bool IsActive { get; set; } = false;

    [Parameter]
    public EventCallback<bool> IsActiveChanged { get; set; }

    public async Task OnSelectedChanged(ChangeEventArgs e)
    {
        await IsActiveChanged.InvokeAsync(!IsActive);
    }
}

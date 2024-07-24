using Microsoft.AspNetCore.Components;

namespace InteractivePageUpdateInsideStatic.Components.Pages;

public partial class WeatherAdminInteractive
{
    private int itemsCount;

    [Inject]
    private WeatherForecastRepository WeatherForecastRepository { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    public WeatherAdminInteractive()
    {

    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            this.itemsCount = this.WeatherForecastRepository.Forecasts.Count();
            await this.InvokeAsync(this.StateHasChanged);
        }
    }

    private void RemoveLast()
    {
        this.WeatherForecastRepository.RemoveLast();

        var absoluteUri = this.NavigationManager.ToAbsoluteUri(this.NavigationManager.Uri);
        this.NavigationManager.NavigateTo(absoluteUri.AbsolutePath);
    }
}

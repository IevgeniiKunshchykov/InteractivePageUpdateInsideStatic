using Microsoft.AspNetCore.Components.Web;

namespace InteractivePageUpdateInsideStatic;

public static class RenderModes
{
    public static InteractiveServerRenderMode InteractiveServerWithoutPreRendering { get; } = new(false);
}

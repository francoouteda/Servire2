using Servire.Bll;
using Servire.Bll.Services;



namespace Servire.UI.Infrastructure;

public sealed class UiSessionContext : ISessionContext
{
    public string? Username => Program.CurrentUser?.Username;
}

namespace BlazorApps.Services;

public class AuthenticationStateService
{
    public bool IsAuthenticated { get; private set; } = false;
    public string? UserName { get; private set; }

    // Event to notify components when state changes
    public event Action? OnChange;

    public void LogIn(string username = "Student")
    {
        IsAuthenticated = true;
        UserName = username;
        NotifyStateChanged();
    }

    public void LogOut()
    {
        IsAuthenticated = false;
        UserName = null;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}

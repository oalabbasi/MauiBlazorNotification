
namespace MauiBlazorNotification.Services
{
    public interface IFirebaseTokenRetriever
    {
        string Token { get; }

        void SaveToken(string token);

    }
}

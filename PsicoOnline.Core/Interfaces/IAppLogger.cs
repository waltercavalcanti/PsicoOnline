namespace PsicoOnline.Core.Interfaces
{
    public interface IAppLogger<T>
    {
        void LogInformationAsync(string message, params object[] args);

        void LogWarningAsync(string message, params object[] args);

        void LogErrorAsync(string message, Exception ex);
    }
}
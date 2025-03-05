using NLog;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.Infrastructure.Logging;

public class AppLogger<T> : IAppLogger<T>
{
	private static readonly Logger NLog = LogManager.GetCurrentClassLogger();
	private static readonly string ClassName = $"{typeof(T).Name}|";

	public void LogError(string message, Exception ex) => NLog.Error(ex, message);

	public void LogInformation(string message, params object[] args) => NLog.Info(ClassName + message, args);

	public void LogWarning(string message, params object[] args) => NLog.Warn(ClassName + message, args);
}
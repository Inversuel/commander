namespace commander.application.Interface.Services
{
  public interface IDateTimeProvider
  {
    DateTime UtcNow { get; }
  }
}
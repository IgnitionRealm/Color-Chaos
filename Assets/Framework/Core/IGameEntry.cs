namespace IgnitionRealm.Framework.Core
{
    /// <summary>
    /// Creates the application for a specific game.
    /// </summary>
    public interface IGameEntry
    {
        App CreateApp();
    }
}
namespace IgnitionRealm.Framework.Core
{
    /// <summary>
    /// Base interface implemented by every framework manager.
    /// </summary>
    /// 
    /// ============================================================================
    // Ignition Framework
    // File: IManager.cs
    // Version: 1.0
    // Status: Stable
    // ============================================================================
    public interface IManager
    {
        void Initialize();
        void Shutdown();
    }
}
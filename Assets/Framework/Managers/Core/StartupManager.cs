using UnityEngine;
using IgnitionRealm.Framework.Core;

namespace IgnitionRealm.Framework.Managers.Core
{
    /// <summary>
    /// Responsible for framework startup tasks.
    /// This is the first manager initialized by the application.
    /// </summary>
    public class StartupManager : ManagerBase
    {
        public override void Initialize()
        {
            base.Initialize();

            if (FrameworkSettings.EnableDebugLogging)
            {
                Debug.Log($"[{FrameworkSettings.FrameworkName}] StartupManager initialized.");
                Debug.Log($"Framework Version: {FrameworkSettings.Version}");
            }
        }

        public override void Shutdown()
        {
            if (FrameworkSettings.EnableDebugLogging)
            {
                Debug.Log($"[{FrameworkSettings.FrameworkName}] StartupManager shutdown.");
            }

            base.Shutdown();
        }
    }
}
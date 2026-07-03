using UnityEngine;
using IgnitionRealm.Framework.Builders;
using IgnitionRealm.Framework.Managers.Core;

namespace IgnitionRealm.Framework.Core
{
    /// <summary>
    /// Entry point of the Ignition Framework.
    /// Responsible for configuring the application and
    /// starting the framework.
    /// </summary>
    public class Bootstrap : MonoBehaviour
    {
        private App app;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            ApplyFrameworkSettings();

            app = new AppBuilder()
                .Add<StartupManager>()
                .Build();

            app.Initialize();
        }

        private void OnApplicationQuit()
        {
            app?.Shutdown();

            ManagerRegistry.Clear();
        }

#if UNITY_EDITOR
        private void OnDestroy()
        {
            // Unity Editor doesn't always call OnApplicationQuit
            // when exiting Play Mode, so we shut down here as well.
            if (Application.isPlaying)
            {
                app?.Shutdown();
                ManagerRegistry.Clear();
            }
        }
#endif

        /// <summary>
        /// Applies the global framework configuration.
        /// </summary>
        private static void ApplyFrameworkSettings()
        {
            Application.targetFrameRate = FrameworkSettings.TargetFrameRate;
            Application.runInBackground = FrameworkSettings.RunInBackground;

            QualitySettings.vSyncCount =
                FrameworkSettings.EnableVSync ? 1 : 0;

            if (FrameworkSettings.EnableDebugLogging)
            {
                Debug.Log("========================================");
                Debug.Log($"{FrameworkSettings.FrameworkName} v{FrameworkSettings.Version}");
                Debug.Log("Framework settings applied.");
                Debug.Log("========================================");
            }
        }
    }
}
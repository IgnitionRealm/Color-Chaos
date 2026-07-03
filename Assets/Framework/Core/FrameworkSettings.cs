using UnityEngine;

namespace IgnitionRealm.Framework.Core
{
    /// <summary>
    /// Global configuration for the Ignition Framework.
    /// All framework-wide settings should be defined here.
    /// </summary>
    public static class FrameworkSettings
    {
        /// <summary>
        /// Target frame rate for the application.
        /// Set to -1 to use the platform default.
        /// </summary>
        public const int TargetFrameRate = 120;

        /// <summary>
        /// Enable or disable vertical synchronization.
        /// </summary>
        public const bool EnableVSync = false;

        /// <summary>
        /// Should the application continue running when it loses focus?
        /// </summary>
        public const bool RunInBackground = true;

        /// <summary>
        /// Enable framework debug logging.
        /// </summary>
        public const bool EnableDebugLogging = true;

        /// <summary>
        /// Framework name displayed in logs.
        /// </summary>
        public const string FrameworkName = "Ignition Framework";

        /// <summary>
        /// Current framework version.
        /// </summary>
        public const string Version = "1.0.0";
    }
}
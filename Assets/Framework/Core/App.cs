using System;
using System.Collections.Generic;
using UnityEngine;

namespace IgnitionRealm.Framework.Core
{
    /// <summary>
    /// Represents the running application.
    /// Responsible for initializing and shutting down all registered managers.
    /// </summary>
    public class App
    {
        private readonly List<IManager> managers;

        public App(List<IManager> managers)
        {
            this.managers = managers ?? throw new ArgumentNullException(nameof(managers));
        }

        /// <summary>
        /// Initializes all managers in registration order.
        /// </summary>
        public void Initialize()
        {
            Debug.Log("========== Ignition Framework ==========");
            Debug.Log("Initializing application...");

            foreach (var manager in managers)
            {
                try
                {
                    manager.Initialize();
                    Debug.Log($"[App] Initialized: {manager.GetType().Name}");
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                    throw;
                }
            }

            Debug.Log("Application initialized successfully.");
            Debug.Log("========================================");
        }

        /// <summary>
        /// Shuts down all managers in reverse registration order.
        /// </summary>
        public void Shutdown()
        {
            Debug.Log("========== Ignition Framework ==========");
            Debug.Log("Shutting down application...");

            for (int i = managers.Count - 1; i >= 0; i--)
            {
                try
                {
                    managers[i].Shutdown();
                    Debug.Log($"[App] Shutdown: {managers[i].GetType().Name}");
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }
            }

            Debug.Log("Application shutdown complete.");
            Debug.Log("========================================");
        }
    }
}
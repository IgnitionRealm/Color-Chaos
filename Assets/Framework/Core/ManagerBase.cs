using UnityEngine;

namespace IgnitionRealm.Framework.Core
{
    /// <summary>
    /// Base class for every framework manager.
    /// </summary>
    public abstract class ManagerBase : MonoBehaviour, IManager
    {
        /// <summary>
        /// Has this manager been initialized?
        /// </summary>
        public bool IsInitialized { get; private set; }

        public virtual void Initialize()
        {
            IsInitialized = true;
        }

        public virtual void Shutdown()
        {
            IsInitialized = false;
        }
    }
}
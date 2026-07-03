using System;
using System.Collections.Generic;

namespace IgnitionRealm.Framework.Core
{
    /// <summary>
    /// Central registry for all framework managers.
    /// Provides type-safe access without scene searches.
    /// </summary>
    public static class ManagerRegistry
    {
        private static readonly Dictionary<Type, IManager> managers = new();

        public static void Register<T>(T manager) where T : class, IManager
        {
            Type type = typeof(T);

            if (managers.ContainsKey(type))
                throw new Exception($"{type.Name} is already registered.");

            managers.Add(type, manager);
        }

        public static T Get<T>() where T : class, IManager
        {
            Type type = typeof(T);

            if (!managers.TryGetValue(type, out IManager manager))
                throw new Exception($"{type.Name} has not been registered.");

            return manager as T;
        }

        public static bool TryGet<T>(out T manager) where T : class, IManager
        {
            if (managers.TryGetValue(typeof(T), out IManager value))
            {
                manager = value as T;
                return true;
            }

            manager = null;
            return false;
        }

        public static void Clear()
        {
            managers.Clear();
        }
    }
}
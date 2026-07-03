using System;
using System.Collections.Generic;
using UnityEngine;
using IgnitionRealm.Framework.Core;

namespace IgnitionRealm.Framework.Builders
{
    /// <summary>
    /// Builds the application by creating, registering,
    /// and preparing framework managers.
    /// </summary>
    public class AppBuilder
    {
        private readonly GameObject appObject;
        private readonly List<IManager> managers = new();
        private readonly HashSet<Type> registeredTypes = new();

        private bool isBuilt;

        public AppBuilder()
        {
            appObject = new GameObject("__App");
            UnityEngine.Object.DontDestroyOnLoad(appObject);
        }

        /// <summary>
        /// Adds a manager to the application.
        /// </summary>
        public AppBuilder Add<T>()
            where T : ManagerBase
        {
            if (isBuilt)
                throw new InvalidOperationException("Cannot add managers after Build() has been called.");

            Type type = typeof(T);

            if (!registeredTypes.Add(type))
                throw new InvalidOperationException($"{type.Name} has already been added.");

            T manager = appObject.AddComponent<T>();

            managers.Add(manager);

            ManagerRegistry.Register(manager);

            return this;
        }

        /// <summary>
        /// Builds the application.
        /// </summary>
        public App Build()
        {
            if (isBuilt)
                throw new InvalidOperationException("Build() has already been called.");

            isBuilt = true;

            return new App(managers);
        }
    }
}
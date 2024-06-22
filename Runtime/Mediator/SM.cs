/*
 * Author: Simple Game Studio29
 * License: https://github.com/Kruty1918/Unity-MonoSingleton-System/blob/main/LICENSE.txt
 * Year: 2024
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using SGS29.Utilities.Mediators;

namespace SGS29.Utilities
{
    /// <summary>
    /// SM (Singleton Mediator) Class for managing singletons. 
    /// </summary>
    public static class SM
    {
        /// <summary>
        /// Dictionary to store singleton instances.
        /// </summary>
        private static Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        /// <summary>
        /// Variable to indicate whether to display debug messages.
        /// </summary>
        private static bool isDebuggingMessage;

        /// <summary>
        /// Property to get the state of debug messages.
        /// </summary>
        public static bool IsDebuggingMessage { get => isDebuggingMessage; }

        /// <summary>
        /// Property to check if singleton instances have been initialized.
        /// </summary>
        public static bool AreInstancesInitialized => _instances.Count > 0;

        /// <summary>
        /// Get an instance of the singleton of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of the singleton.</typeparam>
        /// <returns>Instance of the singleton.</returns>
        public static T Instance<T>() where T : class, ISingletonMediator<T>, new()
        {
            var type = typeof(T);
            if (!_instances.ContainsKey(type))
            {
                Debug.LogError($"Instance of type {type} not found. Ensure it is created and registered before attempting to access it.");
                return null;
            }

            return (T)_instances[type];
        }

        /// <summary>
        /// Register a singleton instance.
        /// </summary>
        /// <typeparam name="T">Type of the singleton.</typeparam>
        /// <param name="instance">Singleton instance.</param>
        internal static void RegisterSingleton<T>(T instance) where T : class
        {
            var type = typeof(T);
            if (!_instances.ContainsKey(type))
            {
                _instances[type] = instance;
            }
            else
            {
                Debug.LogWarning($"Singleton of type {type} is already registered. Skipping registration.");
            }
        }

        /// <summary>
        /// Unregister a singleton instance.
        /// </summary>
        /// <typeparam name="T">Type of the singleton.</typeparam>
        internal static void UnregisterSingleton<T>() where T : class
        {
            var type = typeof(T);
            if (_instances.ContainsKey(type))
            {
                _instances.Remove(type);
            }
            else
            {
                Debug.LogWarning($"Singleton of type {type} not found. Skipping unregistration.");
            }
        }

        /// <summary>
        /// Check if a singleton instance of the specified type is registered.
        /// </summary>
        /// <typeparam name="T">Type of the singleton.</typeparam>
        /// <returns>True if the singleton is registered, otherwise False.</returns>
        public static bool HasSingleton<T>() where T : class
        {
            var type = typeof(T);
            bool hasSingleton = _instances.ContainsKey(type);

            if (!hasSingleton)
            {
                Debug.LogWarning($"Singleton of type {type} not found.");
            }

            return hasSingleton;
        }

        /// <summary>
        /// Try to get an instance of the singleton of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of the singleton.</typeparam>
        /// <param name="instance">Singleton instance (output parameter).</param>
        /// <returns>True if the singleton instance is successfully obtained, otherwise False.</returns>
        public static bool TryGetInstance<T>(out T instance) where T : class, ISingletonMediator<T>, new()
        {
            instance = null;

            if (!AreInstancesInitialized)
            {
                Debug.LogWarning("Singleton instances are not initialized.");
                return false;
            }

            var type = typeof(T);
            if (!_instances.ContainsKey(type))
            {
                Debug.LogWarning($"Singleton of type {type} not found.");
                return false;
            }

            instance = (T)_instances[type];
            return true;
        }
    }
}

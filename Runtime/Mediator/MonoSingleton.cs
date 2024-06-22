/*
 * Author: Simple Game Studio29
 * License: https://github.com/Kruty1918/Unity-MonoSingleton-System/blob/main/LICENSE.txt
 * Year: 2024
 */

using System;
using UnityEngine;
using SGS29.Utilities.Mediators;

namespace SGS29.Utilities
{
    /// <summary>
    /// MonoSingleton is an abstract base class that implements the Singleton design pattern for MonoBehaviour.
    /// </summary>
    public abstract class MonoSingleton<T> : MonoBehaviour, ISingletonMediator<T> where T : class, new()
    {
        // Field for storing the singleton instance
        private static T instance;
        // Field for identifying a duplicate
        private bool isDuplicate;

        /// <summary>
        /// Whether logging will occur
        /// </summary>
        public static bool IsDebuggingMessage => SM.IsDebuggingMessage;

        /// <summary>
        /// Property for getting the singleton instance.
        /// </summary>
        T ISingletonMediator<T>.Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Awake method is called upon object initialization.
        /// </summary>
        protected virtual void Awake()
        {
            try
            {
                // Check if Singleton exists
                if (SM.HasSingleton<T>())
                {
                    // If Singleton already exists, output an error and delete the duplicate
                    // Debug.Log($"[MonoSingleton] Error: Singleton of type {typeof(T)} already exists. Deleting duplicate.");
                    isDuplicate = true;
                    Destroy(gameObject);
                }
                else
                {
                    // If Singleton does not exist, create a new instance
                    instance = this as T;
                    SM.RegisterSingleton(instance);

                    if (IsDebuggingMessage)
                        Debug.Log($"[MonoSingleton] Singleton of type {typeof(T)} successfully created.");
                }
            }
            catch (Exception ex)
            {
                // Output an error if there are problems during Singleton initialization
                if (IsDebuggingMessage)
                    Debug.LogError($"[MonoSingleton] Error during initialization of Singleton of type {typeof(T)}: {ex.Message}");
            }
        }

        /// <summary>
        /// OnDestroy method is called upon object destruction.
        /// </summary>
        protected virtual void OnDestroy()
        {
            try
            {
                // Check if Singleton exists and is not a duplicate
                if (instance != null && !isDuplicate)
                {
                    // If Singleton exists and is not a duplicate, delete it
                    SM.UnregisterSingleton<T>();

                    if (IsDebuggingMessage)
                        Debug.Log($"[MonoSingleton] Singleton of type {typeof(T)} successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                // Output an error if there are problems during Singleton deletion

                if (IsDebuggingMessage)
                    Debug.LogError($"[MonoSingleton] Error during deletion of Singleton of type {typeof(T)}: {ex.Message}");
            }
        }
    }
}

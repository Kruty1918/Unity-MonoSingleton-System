/*
 * Author: Simple Game Studio29
 * License: https://github.com/Kruty1918/Unity-MonoSingleton-System/blob/main/LICENSE.txt
 * Year: 2024
 */

namespace Utilities.Mediators
{
    /// <summary>
    /// The ISingletonMediator interface defines a contract for Singleton mediators.
    /// </summary>
    public interface ISingletonMediator<T> where T : class
    {
        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        T Instance { get; }
    }
}

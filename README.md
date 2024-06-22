# Unity MonoSingleton System
MonoSingleton is a centralized system for Unity that automates instance management. It simplifies development, improves code readability, and allows you to focus on core aspects of game development. MonoSingleton also prevents errors by managing instances within the scene.

## Getting Started
To get started with **MonoSingleton**, inherit from the MonoSingleton class in the script you want to make a singleton. Specify the class name in the generic type parameter **<T>**. For example, if your script is called **MyMonoSingletonScript**, you should write it as **MonoSingleton<MyMonoSingletonScript>**.

```
using SGS29.Utilities;

public class MyMonoSingletonScript : MonoSingleton<MyMonoSingletonScript>
{
}
```

When the object that inherits from **MonoSingleton** awakens, it is automatically initialized. To get the singleton instance from the scene, use the **Singleton Mediator (SM)** object.

## Example

```
using SGS29.Utilities;

public class MyMonoSingletonScript : MonoSingleton<MyMonoSingletonScript>
{
    public void Play()
    {
        Debug.Log("Play!");
    }
}

public class CallerScript
{
    public void SomeMethod()
    {
        SM.Instance<MyMonoSingletonScript>().Play();
    }
}
```

In this example, **SM.Instance<MyMonoSingletonScript>()** retrieves the singleton instance of **MyMonoSingletonScript** from the scene.

## Using the Awake Method

If your script inheriting from **MonoSingleton** needs to use the Awake method, it should be called as follows:

```
public class MyMonoSingletonScript : MonoSingleton<MyMonoSingletonScript>
{
    protected override void Awake()
    {
        base.Awake();
        // Custom logic for Awake
    }
}
```

It is recommended to first call the base method **base.Awake();** and then perform your logic. This ensures that the object is initialized as a singleton first.

### Using the DontDestroyOnLoad Method

The **DontDestroyOnLoad()** method can be easily integrated into this system to prevent the object from being destroyed when loading a new scene. If a singleton object exists in the newly loaded scene that matches the one from the previous scene, the new object will be destroyed, and the old singleton object will remain. A message will be logged to notify you that a duplicate singleton was detected and removed.

## Error Logging

**MonoSingleton** includes built-in error logging to notify you if something goes wrong or if you forget any necessary steps. This ensures smooth operation and helps in debugging issues related to singleton instances.

# Installation

- Clone or download the repository or the latest release from GitHub.
- Import **MonoSingleton** scripts into your **Unity project**.
- Inherit your scripts from **MonoSingleton<T>** to make them singletons.

## Usage

- Create a script and inherit it from **MonoSingleton<T>**.
- Access the singleton instance using **SM.Instance<T>()**.

**By following these steps, you can easily manage singleton instances in your Unity project, making development more streamlined and efficient.**

____________________________________________________

*Feel free to contribute to the project by submitting issues or pull requests on the GitHub repository. For any questions or **support**, contact the maintainers.*

using UnityEngine;


public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T Instance;
    public static T instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = Resources.Load<T>(typeof(T).ToString());
                (Instance as SingletonScriptableObject<T>).OnInitialize();
            }
            return Instance;
        }
    }

    // Optional overridable method for initializing the instance.
    protected virtual void OnInitialize() { }

}
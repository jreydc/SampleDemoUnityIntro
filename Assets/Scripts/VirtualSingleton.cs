using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VirtualSingleton<T> : VirtualSingleton where T : MonoBehaviour
{
    #region  Fields
    private static T _instance;

    // ReSharper disable once StaticMemberInGenericType
    private static readonly object Lock = new object();

    [SerializeField]
    private bool _persistent = true;
    #endregion

    #region  Properties
    public static T Instance
    {
        get
        {
            if (Quitting)
            {
                Debug.LogWarning($"[{nameof(VirtualSingleton)}<{typeof(T)}>] Instance will not be returned because the application is quitting.");
                // ReSharper disable once AssignNullToNotNullAttribute
                return null;
            }
            lock (Lock)
            {
                if (_instance != null)
                    return _instance;
                var instances = FindObjectsOfType<T>();
                var count = instances.Length;
                if (count > 0)
                {
                    if (count == 1)
                        return _instance = instances[0];
                    Debug.LogWarning($"[{nameof(VirtualSingleton)}<{typeof(T)}>] There should never be more than one {nameof(VirtualSingleton)} of type {typeof(T)} in the scene, but {count} were found. The first instance found will be used, and all others will be destroyed.");
                    for (var i = 1; i < instances.Length; i++)
                        Destroy(instances[i]);
                    return _instance = instances[0];
                }

                Debug.Log($"[{nameof(VirtualSingleton)}<{typeof(T)}>] An instance is needed in the scene and no existing instances were found, so a new instance will be created.");
                return _instance = new GameObject($"({nameof(VirtualSingleton)}){typeof(T)}")
                           .AddComponent<T>();
            }
        }
    }
    #endregion

    #region  Methods
    private void Awake()
    {
        if (_persistent)
            DontDestroyOnLoad(gameObject);
        OnAwake();
    }

    protected virtual void OnAwake() { }
    #endregion
}

public abstract class VirtualSingleton : MonoBehaviour
{
    #region  Properties
    public static bool Quitting { get; private set; }
    #endregion

    #region  Methods
    private void OnApplicationQuit()
    {
        Quitting = true;
    }
    #endregion
}
//public class Singleton<T> : MonoBehaviour where T : new()
//{
//    //private static T _instance;
//    //// Explicit static constructor to tell C# compiler  
//    //// not to mark type as beforefieldinit  
//    //public static T Instance
//    //{
//    //    get
//    //    {
//    //        if (_instance == null)
//    //        {
//    //            _instance = new T();
//    //            Debug.Log(typeof(T).ToString() + " is NULL.");
//    //        }
//    //        return _instance;
//    //    }
//    //}


//}
    //private static T Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            _instance = this as T;
    //            Debug.Log(typeof(T).ToString() + " is NULL.");
    //        }
    //        return _instance;
    //    }

//}

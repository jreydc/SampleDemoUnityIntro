using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: Singleton<T>
{
    public static T _Instance;

    void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this as T;
        }else
        {
            Destroy(gameObject);
        }
    }
}

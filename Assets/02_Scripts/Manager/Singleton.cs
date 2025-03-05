using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance != null)
                {
                    _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                }
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
    protected virtual void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(this);
    }
}

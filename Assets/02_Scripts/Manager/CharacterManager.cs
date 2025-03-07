using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterManager : MonoBehaviour
{
   private static ChracterManager _instance;
    public static ChracterManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameObject("ChracterManager").AddComponent<ChracterManager>();  
            }
            return _instance;
        }
    }
    public Player _player;
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
                Destroy(gameObject);
        }

    }
}

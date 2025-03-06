using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    private void Awake()
    {
        if(ChracterManager.Instance != null)
        {
            ChracterManager.Instance.SetPlayer(this);
        }
        controller = GetComponent<PlayerController>();
    }
}

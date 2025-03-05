using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        if(ChracterManager.Instance != null)
        {
            ChracterManager.Instance.SetPlayer(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool isOpen = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void ToggleDoor()
    {
        if (isOpen)
        {
            anim.SetBool("DoorOpen",false);
        }
        else
        {
            anim.SetBool("DoorOpen",true);
        }
        isOpen = !isOpen;
    }
    private void OnTriggerEnter(Collider others)
    {
        if (others.gameObject.CompareTag("Player"))
        {
            Debug.Log("문 열어라");
            ToggleDoor();
        }
    }
}

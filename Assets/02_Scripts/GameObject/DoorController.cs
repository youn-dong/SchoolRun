using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DoorController : MonoBehaviour, IInterEnvironment
{
    private bool isOpen = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void ToggleDoor()
    {
        isOpen = !isOpen;

        anim.SetBool("DoorOpen", isOpen);
        Debug.Log("문상태: " + (isOpen ? "열림" : "닫힘"));
    }
    public void OnInteractEnvironment()
    {
            Debug.Log("문 열어라");
            ToggleDoor();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExitButton : MonoBehaviour
{
    public GameObject gamePanel;

    private void Start()
    {
        gamePanel.gameObject.SetActive(true);
    }
    public void ClosePanel()
    {
        gamePanel.SetActive(false);
    }
}

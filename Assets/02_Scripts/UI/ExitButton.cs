using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameObject gamePanel;

    private void Start()
    {
        gamePanel.SetActive(true);   
    }
    public void ExitGamePanel()
    {
        gamePanel.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICursor : MonoBehaviour
{
    public Sprite cursorImage;
    private Image imageComponent;
    void Start()
    {
        Cursor.visible = false; 
        imageComponent = GetComponent<Image>();
        if(cursorImage != null)
        {
            imageComponent.sprite = cursorImage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        imageComponent.transform.position = Input.mousePosition;
    }
}

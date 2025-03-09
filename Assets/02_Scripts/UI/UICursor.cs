using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICursor : MonoBehaviour
{
    [Header("Design")]
    public Sprite cursorImage;
    private Image imageComponent;
    void Start()
    {
        Cursor.visible = false;  // 현재 사용중인 마우스의 커서를 비활성화
        imageComponent = GetComponent<Image>();
        if(cursorImage != null)
        {
            imageComponent.sprite = cursorImage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        imageComponent.transform.position = Input.mousePosition; // 적용된 이미지의 위치를 마우스의 위치로 만들기위해
    }
}

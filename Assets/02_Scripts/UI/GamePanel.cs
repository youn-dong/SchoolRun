using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [Header("아이템 슬롯")]
    public Button[] itemSlots;
    public Image[] itemImages;

    [Header("아이템 정보")]
    public TextMeshProUGUI itemNameTxt;
    public TextMeshProUGUI itemDescriptionTxt;

    private ItemData[] items = new ItemData[5];

    private void Start()
    {
        for(int i=0; i< itemSlots.Length; i++)
        {
            itemSlots[i].onClick.AddListener(() => ShowItemInfo(i));
        }
    }

    public void SetItems(ItemData[] newItems) //아이템 슬롯에 아이템을 설정
    {
        items = newItems; 
        for(int i = 0; i< items.Length; i++) 
        {
            if (i < items.Length && items[i] != null)
            {
                itemImages[i].sprite = items[i].icon;
                itemSlots[i].gameObject.SetActive(true);
            }
            else
            {
                itemImages[i].sprite = null; //이미지를 제거
                 itemSlots[i].gameObject.SetActive(false); // 슬롯을 비활성화
            }
        }
    }
    public void ShowItemInfo(int index) //아이템 클릭시 아이템의 정보를 표시하는 메서드
    {
        if (items[index] != null)  //아이템이 존재한다면
        {
            itemNameTxt.text = items[index].itemName; //인덱스에 맞는 아이템 이름이 표시되도록 설정
            itemDescriptionTxt.text = items[index].description;
        }
    }
}

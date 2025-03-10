using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public ItemSlot[] slots;

    public GameObject inventoryWindow;
    public Transform slotPanel;
    public Transform dropPosition;

    [Header("Select Item")]
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatName;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject useButton;
    public GameObject dropButton;

    private PlayerConditions condition;
    private PlayerController controller;

    ItemData selectedItem;
    int selectedItemIndex = 0;

    void Start()
    {
        controller = ChracterManager.Instance.Player.controller;
        condition = ChracterManager.Instance.Player.conditions;
        dropPosition = ChracterManager.Instance.Player.dropPosition;

        controller.inventory += Toggle; //델리게이트를 통한 Toggle메서드 구독
        ChracterManager.Instance.Player.addItem += AddItem; //AddItem메서드 구독

        inventoryWindow.SetActive(false);
        slots = new ItemSlot[slotPanel.childCount];
        

        for(int i=0; i<slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            slots[i].index = i;
            slots[i].inventory = this;
            slots[i].Clear();
        }
        ClearSelectedItemInfo();
    }

    void ClearSelectedItemInfo()
    {
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        useButton.gameObject.SetActive(false);
        dropButton.gameObject.SetActive(false);
    }
    public void Toggle()
    {
        if(IsOpen())
        {
            inventoryWindow.gameObject.SetActive(false);
        }
        else
        {
            inventoryWindow.gameObject.SetActive(true);
        }
    }
    public bool IsOpen()
    {
        return inventoryWindow.activeInHierarchy; //인벤토리창이 Hierachy창에서 활성화로 반환
    }
    void AddItem()
    {
        ItemData data = ChracterManager.Instance.Player.itemData; //아이템 데이터는 ChracterManager를 통해서 접근

        if(data.canStack) //아이템이 저장가능한 아이템이라면
        {
            ItemSlot slot = GetItemStack(data); //아이템 슬롯안에 스택할 수 있도록 데이터를 넘겨주고
            if (slot != null)  //슬롯이 비어있지 않다면
            {
                slot.quantity++; //저장갯수를 증가해주고 
                UpDateUI(); // UI를 Update하고
                ChracterManager.Instance.Player.itemData = null;
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot(); // 비어있는 슬롯을 가져오고,

        if (emptySlot != null)
        {
            emptySlot.item = data;
            emptySlot.quantity = 1;
            UpDateUI();
            ChracterManager.Instance.Player.itemData = null;
            return;
        }

        ThrowItem(data);
        ChracterManager.Instance.Player.itemData = null;
    }
    ItemSlot GetItemStack(ItemData data) //저장가능한 아이템 저장이 가능한지
    {
        for(int i =0; i<slots.Length; i++)
        {
            if (slots[i].item == data && slots[i].quantity < data.maxStackAmount) //아이템의 데이터가 있으면서
                                                                                  //설정된 Quantity를 초과하지는 않는지
            {
                return slots[i];
            }
        }
        return null;
    }
    ItemSlot GetEmptySlot() //비어있는 슬롯을 가져오기
    {
        for(int i =0; i<slots.Length; i++) 
        {
            if (slots[i].item == null) //슬롯 상에 아이템이 없다면
            {
                return slots[i]; //아이템을 가져오고
            }
        }
        return null; //슬롯상 저장 공간이 없다면 null을 반환
    }
    void UpDateUI() //UI 업데이트
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null) //슬롯에 데이터가 있다면
            {
                slots[i].Set(); // UI에 세팅
            }
            else
            {
                slots[i].Clear();
            }
        }
    }
    void ThrowItem(ItemData data) // 아이템 버릴 때 
    {
        Instantiate(data.dropPrefab,dropPosition.position,Quaternion.Euler(Vector3.one*Random.value*360));
    }
    public void SelectItem(int index)
    {
        if (slots[index].item == null) return;

        selectedItem = slots[index].item;
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.itemName;
        selectedItemDescription.text = selectedItem.description;

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        for(int i = 0; i<selectedItem.consumables.Length; i++)
        {
            selectedItemStatName.text += selectedItem.consumables[i].type.ToString() + "\n";
            selectedItemStatValue.text += selectedItem.consumables[i].value.ToString() + "\n";
        }
        useButton.SetActive(selectedItem.type == ItemType.Healthy);
        dropButton.SetActive(true);
    }
    public void OnUseButton()
    {
        if (selectedItem.type == ItemType.Healthy)
        {
            for (int i = 0; i < selectedItem.consumables.Length; i++)
            {
                switch (selectedItem.consumables[i].type)
                {
                    case ConsumableType.Health:
                        condition.Heal(selectedItem.consumables[i].value);
                        break;
                    case ConsumableType.Hunger:
                        condition.Eat(selectedItem.consumables[i].value);
                        break;
                }
            }
            RemoveSelectedItem();
        }
    }
    public void OnDropButton()
    {
        ThrowItem(selectedItem);
        RemoveSelectedItem();
    }
    void RemoveSelectedItem()
    {
        slots[selectedItemIndex].quantity--;
        if (slots[selectedItemIndex].quantity<=0)
        {
            selectedItem = null;
            slots[selectedItemIndex].item = null; 
            selectedItemIndex = 1;
            ClearSelectedItemInfo();
        }
        UpDateUI();
    }
}

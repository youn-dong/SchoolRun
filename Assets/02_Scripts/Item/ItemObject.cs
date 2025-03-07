using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();

    public void OnInteract();
}
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;
   public string GetInteractPrompt()
    {
        string str = $"{data.ItemName}\n{data.description}";
        return str;
    }
    public void OnInteract()
    {
        Debug.Log("상호작용중");
        ChracterManager.Instance.Player.itemData = data;
        ChracterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }
}

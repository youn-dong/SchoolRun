using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInterEnvironment
{
    void OnInteractEnvironment();
}

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
        return $"{data.itemName}\n{data.description}";
    }
    public void OnInteract()
    {
        Debug.Log("상호작용중");
        ChracterManager.Instance.Player.itemData = data;
        ChracterManager.Instance.Player.addItem?.Invoke();
        if(ChracterManager.Instance.Player.conditions != null)
        {
            ChracterManager.Instance.Player.conditions.TakeDamage(data);
        }
        Destroy(gameObject);
    }
}

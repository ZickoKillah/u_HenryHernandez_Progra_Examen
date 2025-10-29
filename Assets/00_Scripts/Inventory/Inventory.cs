using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;

public class Inventory : MonoBehaviour
{    
    //Lista que almacena los items del inventario
    public List<Item> itemList = new List<Item>();
    public GameObject inventoryPanel;
    public GameObject itemUI;
    public GameObject inventoryPanelPrefab;
    private bool inventoryVisible = false;
    //Método para agregar item al inventario
    
    public void AddItem(Item itemNew)
    {
        itemList.Add(itemNew);
        Debug.Log("Item Added" + itemNew);
        
        //Actualizar la UI del inventario
        UpdateInventoryUI();
    }

    public void RemoveItem(string itemName)

    {
        Item itemToRemove = null;
        foreach (Item item in itemList)
        {
            //si el nombre que busca la puerta es igual al item
            if (item.nameObject == itemName)
            {  //remueve ese item
                itemToRemove = item;
                break;
            }
        }

        if (itemToRemove != null)
        {
            itemList.Remove(itemToRemove);
            UpdateInventoryUI();
        }
        else
        {
            Debug.LogWarning("No item to remove");
        }
        //buscar item en la liste

        //Si lo encuentras, eliminalo

        //pero si no lo encuentra, avisa con un warning


    }
    public bool HasItem(string itemName)
    {
        foreach (Item itemForEach in itemList)
        {
            if (itemForEach.nameObject == itemName)
            {
                return true;
            }

           
        }
        return false;
    
    }
    public void UpdateInventoryUI()
    {
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in itemList)
        {
            // instanciar el prefab
            GameObject itemUI = Instantiate(inventoryPanelPrefab, inventoryPanel.transform);
            TextMeshProUGUI nametext = itemUI.transform.Find("ItemText").GetComponent<TextMeshProUGUI>();
            nametext.text = item.nameObject;
            //Configurar la imagen del item
            Image iconImage = itemUI.GetComponent<Image>();
            iconImage.sprite = item.icon;
            }
    }

    private void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
           inventoryVisible = !inventoryVisible;
           if (inventoryVisible)
           {
               inventoryPanel.SetActive(inventoryVisible);
               //animar apertura de inventario
               inventoryPanel.transform.localScale = Vector3.zero;
               inventoryPanel.transform.DOScale(1f,0.5f).SetEase(Ease.OutBounce);
           }
           else
           {
               inventoryPanel.transform.DOScale(0f, 0.5f).SetEase(Ease.InBack)
                   .OnComplete(() => inventoryPanel.SetActive(false));

           }
           
          
        }
    }

}

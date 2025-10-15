using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{    
    //Lista que almacena los items del inventario
    public List<Item> itemList = new List<Item>();
    
    //Método para agregar item al inventario
    public void AddItem(Item itemNew)
    {
        itemList.Add(itemNew);
        Debug.Log("Item Added" + itemNew);
    }

    public void RemoveItem(Item itemRemove)
    {
        itemList.Remove(itemRemove);
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

}

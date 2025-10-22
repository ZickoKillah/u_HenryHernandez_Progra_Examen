using UnityEngine;

[System.Serializable]
public class Item

{
    //Nombre del item
    public string nameObject;
    //Descripción del Item
    public string descriptionObject;
    public Sprite icon;
    public Item(string name, string description, Sprite iconSprite)
    {
        nameObject = name;
        descriptionObject = description;
        icon = iconSprite;
    }
}

using UnityEngine;

[System.Serializable]
public class Item
{
    //Nombre del item
    public string nameObject;
    //Descripción del Item
    public string descriptionObject;

    public Item(string name, string description)
    {
        nameObject = name;
        descriptionObject = description;
    }
}

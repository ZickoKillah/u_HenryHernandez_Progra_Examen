using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public bool key1 = false;
    public bool key2 = false;
    private Inventory playerInventory;
    private Collider npc1;
    [SerializeField] private GameObject nPc1;

    private void Start()
    {
        playerInventory = GetComponent<Inventory>();




    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "NPC1":
                key1 = true;
                Item key1Item = new Item("Key1", "Keep on, one more.");
                playerInventory.AddItem(key1Item);
                nPc1.GetComponent<Collider>().enabled = false;



                break;
            case "NPC2":
                key2 = true;
                Item key2Item = new Item("Key2", "Ok, go through it");
                playerInventory.AddItem(key2Item);
                other.GetComponent<Collider>().enabled = false;

                break;
        }
    }

    public bool TodasLasLlaves()
    {
        bool hasKey1 = playerInventory.HasItem("Key1");
        bool hasKey2 = playerInventory.HasItem("Key2");
        return key1 && key2;
    }



}

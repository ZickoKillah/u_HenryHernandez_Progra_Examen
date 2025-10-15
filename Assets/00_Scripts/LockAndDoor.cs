using System;
using UnityEngine;

public class LockAndDoor : MonoBehaviour
{

    public Keys keys;
    [SerializeField] private GameObject door; 
    private Animator doorAnimator;
    private Inventory playerInventory;

    private void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
        playerInventory = playerInventory.GetComponent<Inventory>();
    }
    private void Update(){

       
            
        

        
            /*
            if (keys.TodasLasLlaves())
            {
                playerInventory.RemoveItem();
                playerInventory.RemoveItem();
                doorAnimator.SetBool("Abierto", true);
            }
            */

            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (keys.TodasLasLlaves())
        {
            //Item key1Item = new Item("Key1", "Keep on, one more.");
            //playerInventory.RemoveItem(itemRemove);
        }
    }
}

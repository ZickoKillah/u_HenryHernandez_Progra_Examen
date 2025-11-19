using System;
using UnityEngine;

public class LockAndDoor : MonoBehaviour
{

    public Keys keys;
    [SerializeField] private GameObject door; 
    private Animator doorAnimator;
    private Inventory playerInventory;

    [SerializeField] private GameObject terrain;

    [SerializeField] private GameObject chamberBeggining;
    //[SerializeField] private GameObject doorTrigger;

    private void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerInventory = player.GetComponent<Inventory>();
        }
        else
        {
            Debug.LogError("No player found");
        }
        
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
            doorAnimator.SetBool("Abierto", true);
            playerInventory.RemoveItem(itemName:"Key1");
            playerInventory.RemoveItem(itemName:"Key2");
            terrain.SetActive(true);
            chamberBeggining.SetActive(false);
            
        }

        
        
    }
}

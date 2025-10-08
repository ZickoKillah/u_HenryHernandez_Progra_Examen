using Unity.VisualScripting;
using UnityEngine;

public class Keys : MonoBehaviour
{ 
    public bool key1 = false;
   public bool key2 = false;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "NPC1":
                key1 = true;
                break;
            case "NPC2":
                key2 = true;
                break;
        }
    }

    
        
}

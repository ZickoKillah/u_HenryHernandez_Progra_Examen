using UnityEngine;

public class LockAndDoor : MonoBehaviour
{
    
        
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject pivot;
    

    
    private void OnTriggerEnter(Collider other)
    {
        if (Keys.key1 && Keys.key2)
        {
            
        }
    }
}

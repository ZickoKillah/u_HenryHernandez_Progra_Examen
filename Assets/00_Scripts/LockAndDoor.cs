using UnityEngine;

public class LockAndDoor : MonoBehaviour
{

    public Keys keys;
    [SerializeField] private GameObject door;
    private Animator doorAnimator;


    private void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
    }
    private void Update(){

       
            
        

        
            if (keys.key1 && keys.key2)
            {
                doorAnimator.SetBool("Abierto", true);
            }

            
    }
}

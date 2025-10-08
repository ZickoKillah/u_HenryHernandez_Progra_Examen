using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
  
{public static GameManager instance;
    [Header("HP<3<3")]
        
public float health = 100f;
    

    private void Awake()
    {
        if  (instance == null)
        { instance = this;
        DontDestroyOnLoad(gameObject);
        
        }
        else {
            Destroy(gameObject);
        }


    }
    private void Start()
    {
        Application.targetFrameRate = 60;
    
    } 
    public void Damage (int damage)
    {
        health -= damage;
    }

    public void Heal(int heal)
    {
        health += heal;
    }
    
    
    
}
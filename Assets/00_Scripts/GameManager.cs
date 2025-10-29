using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("02_Scenes/GameOver");
        
    }
    public void Heal(int heal)
    {
        //health += heal;
        health = Mathf.Clamp(health += heal, 0, 100);
    }

    public void Resethealth()
    {
        health = 100f;
    }
    
    
}
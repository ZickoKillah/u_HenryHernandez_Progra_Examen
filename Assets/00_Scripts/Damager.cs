using UnityEngine;
using System.Collections;
public class Damager : MonoBehaviour
{
    private int damage = 10;
    private IEnumerator damager;
    [Header ("Damager")]
   [SerializeField] private GameObject uiDamager;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                StartCoroutine(damager);
                break;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                StopCoroutine(damager);
                break;
        }
    }

    IEnumerator Damage()
    {
        while (GameManager.instance.health > 0)
        {
            yield return new WaitForSeconds(1);
            GameManager.instance.Damage(damage);
            uiDamager.SetActive(true);
            yield return new WaitForSeconds(1);
            GameManager.instance.Damage(damage);
            uiDamager.SetActive(false);
        }
    }
}

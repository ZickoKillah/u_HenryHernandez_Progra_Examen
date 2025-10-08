using System;
using System.Collections;
using UnityEngine;

public class Healer : MonoBehaviour
{
   private IEnumerator healer;
   private int heal = 5;
   [SerializeField] private GameObject uiHealer;

   private void Start()
   {
      healer = Heal();
   }

   private void OnTriggerEnter(Collider other)
   {
      switch (other.tag)
      {
         case "Player":
            StartCoroutine(healer);
            break;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      switch (other.tag)
      {
         case "Player":
            StopCoroutine(healer);
            break;
      }
   }

   IEnumerator Heal()
   {
      while (GameManager.instance.health < 100)
      {
         GameManager.instance.Heal(heal);
         yield return new WaitForSeconds(1);
         uiHealer.SetActive(true);
         GameManager.instance.Heal(heal);
         yield return new WaitForSeconds(1);
         uiHealer.SetActive(false);
      }
      
   }
}

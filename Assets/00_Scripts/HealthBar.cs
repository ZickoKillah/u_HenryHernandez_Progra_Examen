using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class HealthBar : MonoBehaviour
{
  //Referencia al componente scrollbar
  [SerializeField] private Scrollbar healthBar;
  //Referencia al componente textmesh pro
  [SerializeField] private TextMeshProUGUI healthText;
  //Velocidad de la barra
  [SerializeField] private float updateHealth = 0.5f;
  //Valor actual del scrollbar (entre 0 y 1)
  private float currentHealth;
  


  private void Update()
  {
    UpdateHealthBar();
  }
  private void UpdateHealthBar()
  {
      float targetValue = GameManager.instance.health / 100f;
      //Iniciar corrutina
      StartCoroutine(AnimateHealthBar(targetValue));
      
      //Actualizar el texto de la salud (transformarlo a string)
      if (healthText != null)
      {
          healthText.text = GameManager.instance.health.ToString();
      }
  }

  IEnumerator AnimateHealthBar(float targetValue)
  {
      //Mientras el valor actual sea distinto
      while (Mathf.Abs(healthBar.size - targetValue)>0.1f)
      {
          //Time.deltaTime hacen que el juego funcione independiente al framerate, llevando
          //el calculo del tiempo a los segundos que usamos los humanos.
          healthBar.size = Mathf.Lerp(healthBar.size, targetValue, Time.deltaTime * updateHealth);
          yield return null;
          //Metodo:Que el color del handle esté actualizado a los colores que nosotros vamos a querer
          
      }
      //Al finalizar, establecemos el valor exacto
      healthBar.size = targetValue;
  }
}

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
          UpdateHealthColor();
          
      }
      //Al finalizar, establecemos el valor exacto
      healthBar.size = targetValue;
  }

  private void UpdateHealthColor()
  {
      //Obtener el componente image del handle
      Image handleImage = healthBar.handleRect.GetComponent <Image> ();
      //Image handleImage = GameObject.Find("handle").GetComponent<Image>();
      //Calcular el porcentaje de salud
      float healthPercent = (float)GameManager.instance.health / 100f;
    // 2 maneras de cambiar el color
    /*if (healthPercent > 0.5f)
    {
        handleImage.color = Color.lightGreen;
    }
    else if (healthPercent > 0.3f)
    {
        handleImage.color = Color.yellowNice;
    }
    else
    {
        handleImage.color = Color.darkRed;
    }*/
    handleImage.color = healthPercent switch
    {
        > 0.5f => handleImage.color = Color.lightGreen,
        >= 0.3f and <= 0.5f => handleImage.color = Color.lightGoldenRod,
        _ => handleImage.color = Color.darkRed,
    };
  }
}

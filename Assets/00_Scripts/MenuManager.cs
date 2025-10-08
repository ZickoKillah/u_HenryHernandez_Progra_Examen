using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
   public void ButtonStartGame()
   {
      SceneManager.LoadScene("02_Scenes/Sacred Lake");
      GameManager.instance.Resethealth();
      Cursor.lockState = CursorLockMode.Locked;
   }

   public void ButtonRestartGame()
   {
      SceneManager.LoadScene("02_Scenes/MainMenu");
      Cursor.lockState = CursorLockMode.None;
   }

   public void ButtonExitGame()
   {
      Application.Quit();
   }
}

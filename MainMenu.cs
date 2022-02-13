using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    [SerializeField] GameObject mainMenu;
  [SerializeField] GameObject optionsMenu;
   

    void Start()
    {
      
    }

    public void PlayButton()
    {
         SceneManager.LoadScene("Level1");
    }

   public void mainMenuButton()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void OptionsButton()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

     public void QuitButton()
  {
      Application.Quit();
      Debug.Log("Quit!");
  }
}

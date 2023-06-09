using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelect;

    public void Play()
    {
        // Uses scene order to load next scene after main menu.
        // Doc: https://docs.unity.cn/2019.1/Documentation/Manual/BuildSettings.html
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelSelect()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit button clicked.");
    }

    public void ShowMainMenu()
    {
        // Right now this only works to transition between the level select menu and the main menu.
        // If more menus are added, look into generalizing this.

        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void LoadWarehouse(){
        SceneManager.LoadScene("Scenes/Warehouse");
    }
    public void LoadHELL(){
        SceneManager.LoadScene("Scenes/H.E.L.L");
    }

}

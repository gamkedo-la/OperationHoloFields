using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject pauseButtonsPannel;
    [SerializeField] GameObject commandsPannel;

    public void DisplayPauseButtons()
    {
        print("Display pause buttons");
        commandsPannel.SetActive(false);
        pauseButtonsPannel.SetActive(true);
    }

    public void DisplayCommandsPannel()
    {
        print("Display Command Pannels");
        commandsPannel.SetActive(true);
        pauseButtonsPannel.SetActive(false);
    }
}

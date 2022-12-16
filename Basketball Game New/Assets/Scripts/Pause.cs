using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject pause;

    public void MainMenu()
    {
        pause.SetActive(false);
        menu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

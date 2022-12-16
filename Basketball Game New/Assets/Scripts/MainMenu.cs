using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject howToPlay;
    [SerializeField] private GameObject ui;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        ui.SetActive(true);
    }

    public void HowToPlay()
    {
        menu.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

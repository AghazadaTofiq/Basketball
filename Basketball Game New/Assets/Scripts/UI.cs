using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject pause;

    public void Pause()
    {
        ui.SetActive(false);
        pause.SetActive(true);
    }
}

using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject howToPlay;

    public void Back()
    {
        howToPlay.SetActive(false);
        menu.SetActive(true);
    }
}

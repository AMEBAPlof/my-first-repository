using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;

    private void Start()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
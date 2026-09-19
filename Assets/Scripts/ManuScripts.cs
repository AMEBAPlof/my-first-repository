using UnityEngine;

public class ManuScripts : MonoBehaviour
{

    [SerializeField] private GameObject target;
    public void PlayGame()
    {

    }
    public void Setings()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayerOff()
    {
        target.SetActive(false);
    }

    public void PlayerOn()
    {
        target.SetActive(true);
    }
}

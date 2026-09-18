using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;

    private bool isCamera1Active = true;

    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    public void cam()
    {
        
        isCamera1Active = !isCamera1Active;

        camera1.SetActive(isCamera1Active);
        camera2.SetActive(!isCamera1Active);        
    }
}
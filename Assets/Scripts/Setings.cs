using UnityEngine;
using UnityEngine.UI;

public class Setings : MonoBehaviour
{
    public Toggle toggleMusic;
    public Slider sliderVolumeMusic;
    public AudioSource audio;
    public float volume;

    

    private void Start()
    {
        toggleMusic = GameObject.FindGameObjectWithTag("Toggle").GetComponent<Toggle>();
        sliderVolumeMusic = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();

        Load();
        ValueMusic();
    }
    public void SliderMusic()
    {   
        volume = sliderVolumeMusic.value;
        Save();
        ValueMusic();
    }
    public void ToggleMusic()
    {
        if (toggleMusic.isOn)
        {
            volume = 1;
        }
        else
        {
            volume = 0;
            
        }
        Save();
        ValueMusic();
    }

    private void ValueMusic()
    {
        audio.volume = volume;
        sliderVolumeMusic.value = volume;
        if (volume == 0)
        {
            toggleMusic.isOn = false;
        }
        else
        {
            toggleMusic.isOn = true;
        }
    }
    
    private void Save()
    {
        PlayerPrefs.SetFloat("Volume", volume);
    }
    private void Load()
    {
        volume = PlayerPrefs.GetFloat("Volume", volume);
    }

    

}

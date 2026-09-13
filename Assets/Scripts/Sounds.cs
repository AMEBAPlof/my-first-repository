using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource audioScr => GetComponent<AudioSource>();

    public void PlaySound(
        AudioClip clip,
        float volume = 1f,
        bool destroyed = false)
    {
        if (clip == null)
        {
            Debug.LogError("AudioClip не назначен!");
            return;
        }

        if (audioScr == null)
        {
            Debug.LogError("На объекте нет AudioSource!");
            return;
        }

        audioScr.clip = clip;
        audioScr.loop = true;
        audioScr.volume = volume;
        audioScr.Play();
    }

    private void Start()
    {
        if (sounds == null || sounds.Length == 0)
        {
            Debug.LogError("Массив sounds пуст!");
            return;
        }

        PlaySound(sounds[0]);
    }
}
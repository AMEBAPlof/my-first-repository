using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; // Ваш микшер Krug
    [SerializeField] private Slider volumeSlider;   // Ваш Slider
    [SerializeField] private Toggle muteToggle;     // Ваш новый Toggle (флажок)

    [SerializeField, Range(0f, 1f)]
    private float defaultVolume = 0.7f;

    private void Start()
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = defaultVolume;
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }

        if (muteToggle != null)
        {
            muteToggle.onValueChanged.AddListener(ToggleSound);
            ToggleSound(muteToggle.isOn);
        }
        else if (volumeSlider != null)
        {
            ChangeVolume(volumeSlider.value);
        }
    }

    // Метод для ползунка
    public void ChangeVolume(float value)
    {
        if (audioMixer == null) return;

        // Если флажок сейчас выключен (звука нет), не меняем громкость в микшере,
        // чтобы она не включилась случайно при движении скрытого ползунка
        if (muteToggle != null && !muteToggle.isOn) return;

        float dB = Mathf.Lerp(-80f, 0f, value);
        audioMixer.SetFloat("MyVolume", dB);
    }

    // Метод для флажка (включение/выключение)
    public void ToggleSound(bool isSoundOn)
    {
        if (audioMixer == null) return;

        if (isSoundOn)
        {
            // Если флажок включен — возвращаем громкость, которая выставлена на ползунке
            float sliderValue = volumeSlider != null ? volumeSlider.value : 1f;
            float dB = Mathf.Lerp(-80f, 0f, sliderValue);
            audioMixer.SetFloat("MyVolume", dB);
        }
        else
        {
            // Если флажок выключен — мгновенно уводим микшер в полную тишину
            audioMixer.SetFloat("MyVolume", -80f);
        }
    }

    private void OnDestroy()
    {
        if (volumeSlider != null) volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
        if (muteToggle != null) muteToggle.onValueChanged.RemoveListener(ToggleSound);
    }
}

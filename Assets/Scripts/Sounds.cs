using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; // Ваш микшер Krug
    [SerializeField] private Slider volumeSlider;   // Ваш Slider
    [SerializeField] private Toggle muteToggle;     // Ваш новый Toggle (флажок)

    private void Start()
    {
        // Подписываем слайдер на изменения
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }

        // Подписываем флажок на изменения
        if (muteToggle != null)
        {
            muteToggle.onValueChanged.AddListener(ToggleSound);

            // Сразу выставляем звук в зависимости от состояния флажка при старте
            ToggleSound(muteToggle.isOn);
        }
        else if (volumeSlider != null)
        {
            // Если флажка нет, просто ставим звук по слайдеру
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

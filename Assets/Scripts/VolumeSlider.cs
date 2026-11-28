using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider slider;

    void Start()
    {
        slider.minValue = 0.0001f;
        slider.maxValue = 1f;
        slider.SetValueWithoutNotify(Mathf.Max(SaveData.GetMusicVolume(), 0.0001f));
        Apply(slider.value);
        slider.onValueChanged.AddListener(Apply);
    }

    void OnDestroy() => slider.onValueChanged.RemoveListener(Apply);

    void Apply(float v)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(v) * 20f);
        SaveData.SetMusicVolume(v);
    }
}
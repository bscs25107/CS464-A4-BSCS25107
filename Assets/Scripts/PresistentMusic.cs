using UnityEngine;
using UnityEngine.Audio;

public class PersistentMusic : MonoBehaviour
{
    static PersistentMusic instance;
    [SerializeField] AudioMixer mixer;

    void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (instance != this) return;
        float v = Mathf.Max(SaveData.GetMusicVolume(), 0.0001f);
        mixer.SetFloat("MusicVolume", Mathf.Log10(v) * 20f);
    }
}
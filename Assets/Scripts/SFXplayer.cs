using UnityEngine;

public class SFXplayer : MonoBehaviour
{
    public static SFXplayer Instance { get; private set; }

    [SerializeField] AudioSource[] sources;   // 4 sources, Output = SFX group
    [SerializeField] float semitones = 2f;
    int next;

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioClip clip)
    {
        if (clip == null) return;
        AudioSource s = sources[next];
        next = (next + 1) % sources.Length;
        s.pitch = Mathf.Pow(2f, Random.Range(-semitones, semitones) / 12f);
        s.PlayOneShot(clip);
    }
}
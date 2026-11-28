using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    Button button;

    void Awake() => button = GetComponent<Button>();

    void OnEnable() => button.onClick.AddListener(Play);
    void OnDisable() => button.onClick.RemoveListener(Play);

    public void Play()
    {
        if (SFXplayer.Instance != null) SFXplayer.Instance.Play(clip);
    }
}
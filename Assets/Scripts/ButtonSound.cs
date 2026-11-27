using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    public void Play() => SFXplayer.Instance.Play(clip);
}
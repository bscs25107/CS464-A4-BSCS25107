// HitSoundListener.cs
using UnityEngine;

public class HitSoundListener : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] AudioClip hitClip;

    void OnEnable() => health.Damaged += OnHit;
    void OnDisable() => health.Damaged -= OnHit;
    void OnHit(int current, int max) => SFXplayer.Instance.Play(hitClip);
}
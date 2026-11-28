// HitSparksListener.cs  (ParticleSystem: Looping off, Play On Awake off, ek burst)
using UnityEngine;

public class HitSparksListener : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] ParticleSystem sparks;

    void OnEnable() => health.Damaged += OnHit;
    void OnDisable() => health.Damaged -= OnHit;
    void OnHit(int current, int max) => sparks.Play();
}
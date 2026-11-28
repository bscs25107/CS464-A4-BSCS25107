// HealthBarListener.cs
using UnityEngine;

public class HealthBarListener : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] HealthBar bar;

    void Start() => bar.Set(health.Current, health.Max);
    void OnEnable() => health.Damaged += OnHit;
    void OnDisable() => health.Damaged -= OnHit;
    void OnHit(int current, int max) => bar.Set(current, max);
}
using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerLives : MonoBehaviour
{
    [SerializeField] int lives = 3;
    public int Lives => lives;
    public event Action<int> LivesChanged;
    public event Action OutOfLives;

    Health health;
    Rigidbody rb;
    Vector3 start;

    void Awake()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody>();
        start = transform.position;
    }

    void OnEnable() => health.Died += OnDied;
    void OnDisable() => health.Died -= OnDied;

    void OnDied()
    {
        lives--;
        LivesChanged?.Invoke(lives);
        if (lives <= 0) { OutOfLives?.Invoke(); return; }

        rb.linearVelocity = Vector3.zero;
        rb.position = start;
        transform.position = start;
        health.Revive();
    }
}
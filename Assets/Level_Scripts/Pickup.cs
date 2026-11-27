using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public static int Score;
    public static event Action<Pickup> Collected;

    [SerializeField] int points = 10;
    [SerializeField] ParticleSystem burstPrefab;   // Stop Action = Destroy, Looping off
    [SerializeField] AudioClip clip;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Score += points;
        Collected?.Invoke(this);

        SFXplayer.Instance.Play(clip);
        Instantiate(burstPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
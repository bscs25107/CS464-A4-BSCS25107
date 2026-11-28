using UnityEngine;

public class LivesListener : MonoBehaviour
{
    [SerializeField] PlayerLives lives;
    [SerializeField] Hud hud;

    void Start() => hud.SetLives(lives.Lives);
    void OnEnable() => lives.LivesChanged += OnChanged;
    void OnDisable() => lives.LivesChanged -= OnChanged;
    void OnChanged(int value) => hud.SetLives(value);
}
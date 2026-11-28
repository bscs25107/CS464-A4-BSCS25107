using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int, int> Damaged;
    public event Action Died;

    [SerializeField] int max = 5;
    int current;

    public int Current => current;
    public int Max => max;

    void Awake() => current = max;

    public void Damage(int amount)
    {
        if (current <= 0) return;
        current = Mathf.Max(0, current - amount);
        Damaged?.Invoke(current, max);
        if (current == 0) Died?.Invoke();
    }
    public void Revive()
    {
        current = max;
        Damaged?.Invoke(current, max);   
    }
}
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image fill;
    [SerializeField] Image lag;
    [SerializeField] float lagDelay = 0.4f;
    [SerializeField] float lagSpeed = 0.8f;
    float timer;

    public void Set(int current, int max)
    {
        float t = max > 0 ? (float)current / max : 0f;
        fill.fillAmount = t;
        if (t > lag.fillAmount) lag.fillAmount = t;
        timer = lagDelay;
    }

    void Update()
    {
        if (lag.fillAmount <= fill.fillAmount) return;
        timer -= Time.unscaledDeltaTime;
        if (timer > 0f) return;
        lag.fillAmount = Mathf.MoveTowards(lag.fillAmount, fill.fillAmount, lagSpeed * Time.unscaledDeltaTime);
    }
}
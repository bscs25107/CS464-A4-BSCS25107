using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image fill;
    [SerializeField] Image lag;
    float target = 1f;
    float timer;

    public void Set(int current, int max)
    {
        float t = (float)current / max;
        if (t > target) lag.fillAmount = t;   // heal par lag bar sath chale
        target = t;
        fill.fillAmount = t;
        timer = 0.4f;
    }

    void Update()
    {
        if (timer > 0f) { timer -= Time.unscaledDeltaTime; return; }
        lag.fillAmount = Mathf.MoveTowards(lag.fillAmount, target, 0.8f * Time.unscaledDeltaTime);
    }
}
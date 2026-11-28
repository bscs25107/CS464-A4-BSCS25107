using UnityEngine;

public static class SaveData
{
    const string UnlockedKey = "unlocked";
    const string MusicKey = "MusicVolume";
    static string BestKey(int level) => "best" + level;

    public static int GetUnlocked() => PlayerPrefs.GetInt(UnlockedKey, 1);

    public static void Unlock(int level)
    {
        level = Mathf.Min(level, 5);
        if (level > GetUnlocked())
        {
            PlayerPrefs.SetInt(UnlockedKey, level);
            PlayerPrefs.Save();
        }
    }

    public static bool HasBest(int level) => PlayerPrefs.HasKey(BestKey(level));
    public static float GetBest(int level) => PlayerPrefs.GetFloat(BestKey(level), 0f);

    // true agar naya best bana
    public static bool Record(int level, float time)
    {
        if (HasBest(level) && time >= GetBest(level)) return false;
        PlayerPrefs.SetFloat(BestKey(level), time);
        PlayerPrefs.Save();
        return true;
    }

    public static float GetMusicVolume() => PlayerPrefs.GetFloat(MusicKey, 1f);

    public static void SetMusicVolume(float v)
    {
        PlayerPrefs.SetFloat(MusicKey, v);
        PlayerPrefs.Save();
    }
}
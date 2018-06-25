using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GeneralStats {

    public int highScore;

    public List<LocalStats> localStats = new List<LocalStats>();
    public static GeneralStats fromStorage()
    {
        string str = PlayerPrefs.GetString("stats", null);
        GeneralStats stats = JsonUtility.FromJson<GeneralStats>(str);
        if (str == null || stats == null)
        {
            return new GeneralStats();
        }
        return stats;
    }

    public void save()
    {
        string str = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("stats", str);
    }
}
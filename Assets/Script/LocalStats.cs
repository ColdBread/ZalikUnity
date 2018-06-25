using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocalStats {
    public int score;

    public void save()
    {
        GeneralStats stats = GeneralStats.fromStorage();
        if (stats.localStats.Count == 0)
        {
            stats.localStats.Add(new LocalStats { });
        }
        if (stats.highScore < this.score)
        {
            stats.highScore = this.score;
        }
        stats.save();
    }

    public static LocalStats fromStorage()
    {
        GeneralStats stats = GeneralStats.fromStorage();
        if (stats.localStats.Count == 0)
        {
            LocalStats newStats = new LocalStats { };
            return newStats;
        }
        else
        {
            return stats.localStats[0];
        }
        
    }
	
}
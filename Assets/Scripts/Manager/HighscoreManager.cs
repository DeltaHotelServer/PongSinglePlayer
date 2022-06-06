using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;


public class HighscoreManager : MonoBehaviour
{
    [Serializable]
    public class HighscoreContainer
    {
        public HighscoreEntry[] Highscores;

        public static object Highscore { get; set; }
    }

    [Serializable]
    public class HighscoreEntry
    {
        public string Name;
        public int Score;
    }

    private const string FileName = "highscore.json";
    private const int MaxHighscoes = 2;

    private string HighsorceFilePath => Path.Combine(Application.persistentDataPath, FileName);

    private List<HighscoreEntry> _highscores = new List<HighscoreEntry>();

    private void Awake()
    {
        Debug.Log(message:$"Lade Highscores von {HighsorceFilePath}");
        Load();
    }

    private void OnDestroy()
    {
        Save();
    }

    private void Save()
    {
        var highscoreContainer = new HighscoreContainer()
        {
            Highscores = _highscores.ToArray()
        };

        string json = JsonUtility.ToJson(highscoreContainer);
        File.WriteAllText(HighsorceFilePath, contents: json);
    }

    private void Load()
    {
        if (!File.Exists(HighsorceFilePath))
        {
            return;
        }

        var json = File.ReadAllText(HighsorceFilePath);
        var highscoreContainer = JsonUtility.FromJson<HighscoreContainer>(json);

        if (highscoreContainer == null && HighscoreContainer.Highscore == null)
        {
            return;
        }
        _highscores = new List<HighscoreEntry>(highscoreContainer.Highscores);
    }

    private void Add(HighscoreEntry entry)
    {
        _highscores.Insert(index: 0, entry);
        _highscores = _highscores.Take(MaxHighscoes).ToList();
    }

    public bool IsNewHighscore(int score)
    {
        if(score <= 0)
        {
            return false;
        }

        if(_highscores.Count == 0)
        {
            return true;
        }

        var firstEntry = _highscores[0];

        return score > firstEntry.Score;
    }

    public void Add(string playerName, int score)
    {
        if (!IsNewHighscore(score))
        {
            return;
        }
        var entry = new HighscoreEntry()
        {
            Name = playerName,
            Score = score
        };
        Add(entry);
    }

    public List<HighscoreEntry> List()
    {
        return _highscores;
    }
}

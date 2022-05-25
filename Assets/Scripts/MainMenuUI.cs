using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class MainMenuUI : MonoBehaviour
{

    public HighscoreManager HighscoreManager;
    public GameObject HighscoreEntries;
    public GameObject HighscoreEntryUiPrefab;


    private void Start()
    {
        ShowHighscores();
    }

    private void ShowHighscores()
    {
        for (var i = HighscoreEntries.transform.childCount -1; i >= 0; i--)
        {
            var child = HighscoreEntries.transform.GetChild(i);
            Destroy(child.gameObject);
        }
        var highscroes = HighscoreManager.List();

        foreach (var highscore in highscroes)
        {
            var highscoreEntry = Instantiate(HighscoreEntryUiPrefab, HighscoreEntries.transform);
            var textMeshPro = highscoreEntry.GetComponent<TextMeshProUGUI>();
            textMeshPro.text = $"{highscore.Score} - {highscore.Name}";
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Pong");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}

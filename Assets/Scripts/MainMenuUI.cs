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
        //Überprüfen ob ein Highscore eingetragen ist und ein eintrag vorher löschen
        //Check whether a high score is entered and delete an entry beforehand
        for (var i = HighscoreEntries.transform.childCount -1; i >= 0; i--)
        {
            var child = HighscoreEntries.transform.GetChild(i);
            Destroy(child.gameObject);
        }
        var highscroes = HighscoreManager.List();

        //Highscore liste landen und anzeigen
        //landing and displaying the high score list
        foreach (var highscore in highscroes)
        {
            var highscoreEntry = Instantiate(HighscoreEntryUiPrefab, HighscoreEntries.transform);
            var textMeshPro = highscoreEntry.GetComponent<TextMeshProUGUI>();
            textMeshPro.text = $"{highscore.Score} - {highscore.Name}";
        }
    }

    //Scene laden und beenden
    //Load scene and exit
    public void StartGame()
    {
        SceneManager.LoadScene("Pong");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    private float _timeSurvived;

    private float _player1TotalMovement;
    private float _player2TotalMovement;
    private Controls _player1Controls;
    private Controls _player2Controls;

    public GameObject player1;
    public GameObject player2;

    public GameObject[] endScreen;
    public GameObject[] scores;

    private void Start()
    {
        _player1Controls = player1.GetComponent<Controls>();
        _player2Controls = player2.GetComponent<Controls>();
    }

    void Update()
    {
        _player1TotalMovement = _player1Controls.score;

        _player2TotalMovement = _player2Controls.score;
        _timeSurvived += Time.deltaTime;
    }

    public void GameOver()
    {
        int i = 0;
        foreach (GameObject gammie in endScreen)
        {
            endScreen[i].SetActive(true);
            i++;
        }


        int stability1 = (int)Mathf.Round(player1.GetComponent<ParticleStability>()._stability);
        int stability2 = (int)Mathf.Round(player2.GetComponent<ParticleStability>()._stability);


        int score1 = (int)Mathf.Round(_timeSurvived + _player1TotalMovement);
        score1 = score1 + score1 * stability1;
        int score2 = (int)Mathf.Round(_timeSurvived + _player2TotalMovement);
        score2 = score2 + score2 * stability2;

        scores[0].GetComponent<Text>().text = "Score: " + score1;
        scores[1].GetComponent<Text>().text = "Score: " + score2;
        scores[0].transform.parent.GetComponent<Text>().text = "Stability = " + stability1 + "%";
        scores[1].transform.parent.GetComponent<Text>().text = "Stability = " + stability2 + "%";

        Time.timeScale = 0;
    }
}

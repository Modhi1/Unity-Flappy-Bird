using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
   // [SerializeField]
   //private Spawner spawner;

    public TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject gameOver;
    public int score { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
        Play();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        /*
        Woods[] woods = FindObjectsOfType<Woods>();

        for (int i = 0; i < woods.Length; i++)
        {
            Destroy(woods[i].gameObject);
        }
        */
    }

    // display menue
    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}

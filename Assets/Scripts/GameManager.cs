using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BoxManager boxManager;

    public int boxToSpawn;

    [Header("UI Screens")]
    public GameObject GameOverPanel;

    public void Awake()
    {
        boxManager.Setup(this);
        boxManager.SpawnMultipleBoxes(boxToSpawn);
    }

    public void Start()
    {

    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }
}

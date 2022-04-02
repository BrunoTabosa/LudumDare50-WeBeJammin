using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoxManager boxManager;

    [Header("UI Screens")]
    public GameObject GameOverPanel;

    public void Awake()
    {
        boxManager.Setup(this);   
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }
}

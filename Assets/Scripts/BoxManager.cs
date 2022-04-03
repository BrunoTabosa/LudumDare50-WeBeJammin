using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public List<Box> boxes;
    public Box boxPrefab;
    public List<Transform> boxPosition;

    private GameManager gameManager;

    private int boxesAmount = 0;
    private int boxesOccupied = 0;

    public void Setup(GameManager gm)
    {
        boxes = new List<Box>();
        gameManager = gm;
    }

    public void SpawnMultipleBoxes(int boxToSpawn)
    {
        for (int i = 0; i < boxToSpawn; i++)
        {
            if (i >= boxPosition.Count) break;
            SpawnBox(i);
        }
    }

    private void Start()
    {

    }

    public void SpawnBox()
    {
        SpawnBox(0);
    }
    public void SpawnBox(int i)
    {
        var go = Instantiate<Box>(boxPrefab, boxPosition[i].position,
            Quaternion.identity, transform);
        go.Setup(this, gameManager);
        boxes.Add(go);
    }

    public void OnCharacterEnterBox(Box box, Character character)
    {
        boxesOccupied++;

        if (boxesOccupied >= boxes.Count)
        {
            //Game over
            gameManager.OnGameOver();
        }
    }



}

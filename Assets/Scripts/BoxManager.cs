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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Character c = collision.GetComponent<Character>();
            // "Tell managers about that" -Karen
            var box = boxes[boxesOccupied];
            

            //Cat entering in the box
            box.CanInTheBox.SetActive(true);
            box.CatSpriteRenderer.sprite = box.CatSprites[UnityEngine.Random.Range(0, box.CatSprites.Count)];
            box.CatSpriteRenderer.color = c.renderer.color;

            OnCharacterEnterBox(box, c);
            Destroy(collision.gameObject);
        }
    }



}

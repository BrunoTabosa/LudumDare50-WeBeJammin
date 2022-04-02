using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public List<Box> boxes;
    public Box boxPrefab;
    public List<Transform> boxPosition;

    private GameManager gameManager;

    public void Setup(GameManager gm)
    {
        boxes = new List<Box>();
        gameManager = gm;
    }

    private void Start()
    {
        SpawnBox();
    }

    public void SpawnBox()
    {
        SpawnBox(0);
    }
    public void SpawnBox(int i)
    {
        var go = Instantiate(boxPrefab, boxPosition[i].position, 
            Quaternion.identity, transform);
    }



}

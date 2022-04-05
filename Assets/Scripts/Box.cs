using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject CanInTheBox;
    public Collider2D collider;

    public SpriteRenderer CatSpriteRenderer;
    public List<Sprite> CatSprites;

    private BoxManager boxManager;
    private GameManager gameManager;

    public List<Sprite> BoxSprites;
    public SpriteRenderer BoxSpriteRenderer;

    public void Setup(BoxManager bm, GameManager gm)
    {
        boxManager = bm;
        gameManager = gm;
        CanInTheBox.SetActive(false);
        BoxSpriteRenderer.sprite = BoxSprites[Random.Range(0, BoxSprites.Count)];

    }

    


}

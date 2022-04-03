using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject CanInTheBox;
    public Collider2D collider;

    public SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;

    private BoxManager boxManager;
    private GameManager gameManager;

    public void Setup(BoxManager bm, GameManager gm)
    {
        boxManager = bm;
        gameManager = gm;
        CanInTheBox.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Character c = collision.GetComponent<Character>();
            // "Tell managers about that" -Karen
            boxManager.OnCharacterEnterBox(this, c);

            //Cat entering in the box
            CanInTheBox.SetActive(true);
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
            spriteRenderer.color = c.renderer.color;

            collider.enabled = false;
            Destroy(collision.gameObject);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject CanInTheBox;

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
        if (collision.tag == "Character")
        {
            // "Tell managers about that" -Karen
            boxManager.OnCharacterEnterBox(this, collision.GetComponent<Character>());

            //Cat entering in the box
            CanInTheBox.SetActive(true);
            Destroy(collision.gameObject);
        }
    }


}

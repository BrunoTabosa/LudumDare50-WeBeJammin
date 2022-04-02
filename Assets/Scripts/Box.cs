using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject CanInTheBox;

    private BoxManager boxManager;
    private GameManager gameManager;
    
    void Setup(BoxManager bm, GameManager gm)
    {
        CanInTheBox.SetActive(false);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Character")
        {
            //Cat entering in the box

            CanInTheBox.SetActive(true);
            Destroy(collision.gameObject);
            
            // "Tell managers about that" -Karen
        }
    }

    
}

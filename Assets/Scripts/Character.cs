using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public bool IsMovementActive = false;
    private Vector2 target;
    public float movementSpeed;
    public Slider CarinhoSlider;

    private float MaxCarinhoValue = 3f;
    private float currentCarinhoValue = 0f;

    private GameManager gameManager;
    

    public void Setup(GameManager gm)
    {
        gameManager = gm;
        SetTarget(Vector2.zero);
        IsMovementActive = true;
    }

    public void SetTarget(Vector2 newTarget)
    {
        target = newTarget;

    }

    private void Update()
    {
        CarinhoSlider.value = currentCarinhoValue / MaxCarinhoValue;

        
        if (!IsMovementActive) return;
        Move();
    }

    private void OnMouseDown()
    {
        IsMovementActive = false;
        
        
    }

    private void OnMouseDrag()
    {
        currentCarinhoValue += Time.deltaTime;

        if(currentCarinhoValue >= MaxCarinhoValue)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseUp()
    {
        StopCoroutine(returnMovement(0));

        
        StartCoroutine(returnMovement(2f));
    }



    IEnumerator returnMovement(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        IsMovementActive = true;
    }

    public void Move()
    {
        float step = movementSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
}

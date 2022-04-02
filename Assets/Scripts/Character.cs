using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool IsMovementActive = false;
    private Vector2 target;
    public float movementSpeed;

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

        if (!IsMovementActive) return;
        Move();
    }

    public void Move()
    {
        float step = movementSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
}

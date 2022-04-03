using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public bool IsMovementActive = false;
    
    public float movementSpeed;
    public Slider CarinhoSlider;


    private Vector2 target;
    private GameManager gameManager;
    private Animator animator;


    public float MaxCarinhoValue = 5f;
    private float currentCarinhoValue = 0f;

    private float currentStopTimer = 0f;
    public SpriteRenderer renderer;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Start()
    {
        SetTarget(Vector2.zero);
        IsMovementActive = true;
        animator.SetBool("IsWalking", IsMovementActive);
    }


    public void Setup(GameManager gm, CharacterStatsSO stats)
    {
        gameManager = gm;
        SetTarget(Vector2.zero);
        IsMovementActive = true;

        renderer.sprite = stats.sprite;
        renderer.color = stats.color;
        MaxCarinhoValue = stats.CarinhoRequired;
        currentStopTimer = stats.DelayAfterCarinho;
        movementSpeed = stats.MovementSpeed;
        animator.SetBool("IsWalking", IsMovementActive);
    }

    public void SetTarget(Vector2 newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        CarinhoSlider.value = currentCarinhoValue / MaxCarinhoValue;
        
        currentStopTimer -= Time.deltaTime;

        if(currentStopTimer <= 0)
        {
            currentStopTimer = 0;
            IsMovementActive = true;
            
        }
        animator.SetBool("IsWalking", IsMovementActive);
        if (!IsMovementActive) return;
        Move();
    }
    public void Move()  
    {
        float step = movementSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target, step);

    }

    private void OnMouseDown()
    {
        IsMovementActive = false;
        animator.SetBool("IsWalking", IsMovementActive);
    }

    private void OnMouseDrag()
    {
        currentCarinhoValue += Time.deltaTime;
        IsMovementActive = false;
        currentStopTimer = 2f;

        if (currentCarinhoValue >= MaxCarinhoValue)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseUp()
    {
        OnPatEnd();
    }

    void OnPatEnd()
    {
        currentStopTimer = 2f;
    }

    internal void InvertSprite()
    {
        renderer.gameObject.transform.localScale = (new Vector3(-renderer.gameObject.transform.localScale.x, 1, 1));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    [SerializeField] private List<CursorAnimation> cursorAnimationList;
    [SerializeField] private int frameCount;

    private CursorAnimation cursorAnimation;
    public bool IsCursorAnimationActive = false;

    private int currentFrame;
    private float frameTimer;

    public enum CursorType
    {
        Arrow,
        Grab
    }

    private void Start()
    {
        SetActiveCursorAnimation(cursorAnimationList[0]);
    }

    private void Update()
    {
        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0f && IsCursorAnimationActive)
        {
            frameTimer += cursorAnimation.frameRate;
            currentFrame = (currentFrame + 1) % frameCount;
            Cursor.SetCursor(cursorAnimation.textureArray[currentFrame], cursorAnimation.offset, CursorMode.Auto);
        }
    }

    private void SetActiveCursorAnimation(CursorAnimation cursorAnimation)
    {
        this.cursorAnimation = cursorAnimation;
        currentFrame = 0;
        frameTimer = cursorAnimation.frameRate;
        frameCount = cursorAnimation.textureArray.Length;
        Cursor.SetCursor(cursorAnimation.textureArray[currentFrame], cursorAnimation.offset, CursorMode.Auto);
    }

    [System.Serializable]
    public class CursorAnimation 
    {
        public CursorType cursorType;
        public Texture2D[] textureArray;
        public float frameRate;
        public Vector2 offset;

    }
}

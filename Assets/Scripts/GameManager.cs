using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoxManager boxManager;

    public void Awake()
    {
        boxManager.Setup(this);   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Character Stats")]
public class CharacterStatsSO : ScriptableObject
{
    public Sprite sprite;
    public Color color;

    public float CarinhoRequired;
    public float DelayAfterCarinho;
    public float MovementSpeed;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character")]
public class Characters : ScriptableObject
{
    public GameObject playableCharacter;
    public Sprite image;
    public string characterName;
}
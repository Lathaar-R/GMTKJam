using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FaceType
{
    atack,
    defence,
    fire,
    eletric,
    ice
}


[CreateAssetMenu(menuName = "Dice Face")]
public class Face : ScriptableObject
{
    public FaceType faceType;
    public int faceNum;
    public int value;
    //public int pos;
    public Quaternion look;

    public Sprite faceSprite;

}

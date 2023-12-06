using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "UNO Card")]
public class Card : ScriptableObject
{
    public enum Action
    {
        Normal,
        Add,
        Reverse,
        Wild
    }
    public Action action = Action.Normal;
    public enum Color
    {
        Red,
        Green,
        Blue,
        Yellow
    }
    public Color color;

    public int number;
}

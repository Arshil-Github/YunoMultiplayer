using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CardSetMaker : MonoBehaviour
{
    [MenuItem("GameObject/Create Card Set")]
    static void CreateCardSet()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateColorSet(Card.Color.Green, i);
            CreateColorSet(Card.Color.Blue, i);
            CreateColorSet(Card.Color.Red, i);
            CreateColorSet(Card.Color.Yellow, i);
        }

    }
    private static void CreateColorSet(Card.Color color, int i)
    {
        Card newCard = ScriptableObject.CreateInstance<Card>();
        newCard.number = i;
        newCard.color = color;
        AssetDatabase.CreateAsset(newCard, $"Assets/ScriptCreatedCards/{color.ToString()}_{i}.asset");
    }
}

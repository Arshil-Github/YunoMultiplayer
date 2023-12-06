using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    public CardVisualizer selectedCard;

    //A function that selects the card
    public void SelectCard(CardVisualizer cardVisualizer)
    {
        selectedCard = cardVisualizer;
    }
}

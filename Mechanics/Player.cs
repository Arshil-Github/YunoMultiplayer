using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Information that defines each player
    [SerializeField] private List<Card> myCards = new List<Card>();//Assigned at the start of game
    [SerializeField] private string myName;
    [SerializeField] private string id;


    [SerializeField] private GameObject pf_card;
    [SerializeField] private Transform playerCardHolder;

    public struct CardObject
    {
        public Card thisCard;
        public CardVisualizer cardObject;
    }
    private List<CardObject> myCardObjects = new List<CardObject>();
    //This function will be called when a card needs to be added to this players''s queue
    public void receiveCard(Card card) {
        myCards.Add(card);

        //Make a transform corresponding to the thisCard
        CardVisualizer _tempCard = Instantiate(pf_card, playerCardHolder).GetComponent<CardVisualizer>();

        //Add to the card object
        myCardObjects.Add(new CardObject
        {
            thisCard = card,
            cardObject = _tempCard
        });

        _tempCard.CreateThisCard(card);
    }


    //This function will be called when card is palyed to playing decK
    public void playCard(Card card)
    {
        GameManager.Instance.playingDeck.AddCard(card, this);
    }

    //This function will remove a card form myCards
    public void RemoveCard(Card card) {
        try
        {
            myCards.Remove(card);

            foreach (CardObject cO in myCardObjects)
            {
                if (cO.thisCard == card)
                {
                    myCardObjects.Remove(cO);
                    break;
                }
            }
            
            if(myCardObjects.Count == 0)
            {
                Debug.Log("You Win");
            }
        }
        catch(IndexOutOfRangeException e)
        {
            Debug.LogError("The card :" + card.number + " " + card.color + " " + card.action.ToString() + " .The message is " + e);
        }
    }
    /*//Function to be called from the buttton right now might change later
    public void DrawCardFromDeck()
    {
        GameManager.Instance.allCardDeck.GiveCard(GameManager.Instance.currentPlayer);
    }*/
}

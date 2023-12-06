using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCardDeck : MonoBehaviour
{
    [SerializeField] private List<Card> allCards = new List<Card>();//Assigned in Editor
    private List<int> testInts = new List<int>();//Assigned in Editor

    private void Start()
    {
        //Randomize the allCards Deck
        /*for (int i = 0; i < allCards.Count; i++)
        {
            //Randomizing Algorithm
            Card card = allCards[i];
            allCards.Remove(card);
            allCards.Insert(Random.Range(0, testInts.Count), card);
        }*/
        Shuffle<Card>(allCards);
        //Give a certain number of cards to each player
        foreach(Player p in GameManager.Instance.players)
        {
            //For every user keep giving them card till they get enough
            for (int i = 0; i < GameManager.Instance.initialCards; i++) { 
                GiveCard(p);
            }
        }

        //Place one card on the playing deck
        GameManager.Instance.playingDeck.currentCards.Add(allCards[0]);
        GameManager.Instance.playingDeck.topCard = allCards[0];
        GameManager.Instance.playingDeck.ModifyTopCard();
        allCards.RemoveAt(0);

    }

    public void GiveCard(Player user)
    {
        //This function will be called whenever a card needs to be taken from all deck and given to the main deck
        if(allCards.Count == 0)
        {
            Debug.Log("All Cards Exhausted");
            return;
        }

        user.receiveCard(allCards[0]);
        allCards.RemoveAt(0);

        //GameManager.Instance.EndTurn();
    }


    //Function to shuffle a list
    private void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }

}

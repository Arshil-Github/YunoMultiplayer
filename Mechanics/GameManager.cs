using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public void Awake()
    {
        Instance = this;
    }

    public Player currentPlayer;
    public List<Player> players;
    public int initialCards;

    public PlayingDeck playingDeck;
    public AllCardDeck allCardDeck;

    public Transform _dragObjectHolder;

    //This will store all the colors that would be used in the game
    public Color redColor = Color.red;
    public Color greenColor = Color.green;
    public Color blueColor = Color.blue;
    public Color yellowColor = Color.yellow;

    public Color enumToColor(Card.Color c)
    {
        switch (c)
        {
            case Card.Color.Red:
                return redColor;
            case Card.Color.Green:
                return greenColor;
            case Card.Color.Blue:
                return blueColor;
            case Card.Color.Yellow:
                return yellowColor;
            default:
                return Color.white;
        }
    }

    //UI Interface for TurnInfo
    public TextMeshProUGUI playerName;

    //Events at the end of turn
    public event EventHandler endTurnEvents;
    public void EndTurn()
    {
        Debug.Log("Turn was ended");
        //Current player is the next player if there exist a next player, else its the first player again
        currentPlayer = (players.IndexOf(currentPlayer) == players.Count - 1) ? players[0] : players[players.IndexOf(currentPlayer) + 1];

        //Action on changing player ---> Will differ in Netcode part
        foreach (Player p in players)
        {
            p.gameObject.SetActive(currentPlayer == p);
        }
        //Changing UI
        playerName.text = currentPlayer.name;

        endTurnEvents?.Invoke(this, new EventArgs());
    }

    //Call this function from Button to give card to the currentActive Player
    public void GiveCardToCurrentPlayer()
    {
        allCardDeck.GiveCard(currentPlayer);
    }
}

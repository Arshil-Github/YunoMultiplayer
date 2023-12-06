using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayingDeck : MonoBehaviour
{
    public List<Card> currentCards = new List<Card>();
    public Card topCard;
    public Image myImage;
    [SerializeField] private TextMeshProUGUI myNumber;

    //Takes in a card scriptable and modify itself according to it
    public void ModifyTopCard()
    {
        Card c = topCard;
        myImage.color = GameManager.Instance.enumToColor(c.color);
        myNumber.text = c.number.ToString();
    }
    public bool AddCard(Card card, Player player)
    {
        //For Normal Cards
        //If the played card matches the same color or number as the top card then 

        switch (card.action)
        {
            case Card.Action.Normal:
                if(card.color == topCard.color || ((card.number == topCard.number) & (topCard.action == Card.Action.Normal)))
                {
                    //The card play was successful
                    currentCards.Insert(0, card);
                    topCard = card;
                    player.RemoveCard(card);

                    ModifyTopCard();

                    GameManager.Instance.EndTurn();//End this Turn
                    return true;
                }
                break;
            case Card.Action.Add:
                //Will add this later
                break;
            case Card.Action.Reverse:
                //Will add this later
                break;
            case Card.Action.Wild:
                //Will add this later
                break;
            default:
                break;
        }

        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardVisualizer : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Image myImage;
    [SerializeField] private TextMeshProUGUI myNumber;


    private Card thisCard;

    //Takes in a card scriptable and modify itself according to it
    public void CreateThisCard(Card c)
    {
        myImage.color = GameManager.Instance.enumToColor(c.color);
        myNumber.text = c.number.ToString();

        thisCard = c;
    }

    //Drag and Drop Handler

    private Vector3 originalPos;
    private Transform originalParent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPos = Input.mousePosition;
        originalParent = transform.parent;

        transform.SetParent(GameManager.Instance._dragObjectHolder.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

        /*if(rectOverlaps(myImage.rectTransform, GameManager.Instance.playingDeck.myImage.rectTransform))
        {
            Debug.Log("Yes its overlapping");
        }*/
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //For now lets leave it as is we can handle the snapping part later

        bool isDropSuccessful = GameManager.Instance.playingDeck.AddCard(thisCard, GameManager.Instance.currentPlayer);

        if(isDropSuccessful)
        {
            //If its successfull
            Destroy(gameObject);
        }
        else
        {
            //If it failed
            transform.position = originalPos;
            transform.SetParent(originalParent);
        }

    }
}

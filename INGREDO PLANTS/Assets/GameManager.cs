using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<int> WildDeck = new List<int>();//List of wild deck cards
    public List<int> ProportionsWild = new List<int>();//List of card proportion in wild deck
    public GameObject EmptyCard; //Defined as Card prefab in unity under script components of GameManager
    public GameObject RecyclePile; //Defined as RecyclePile prefab in unity under script components of GameManager
    void Start()
    {
        int StartingHandSize = 6;
        int DrawCounter = 0;

        //Generate new deck
        for(int i = 0; i < ProportionsWild.Count; i++)       
        {
            for(int j = 0; j < ProportionsWild[i]; j++)       
            {
                WildDeck.Add(i);
            }
        }
        //Shuffle the deck
        int n = WildDeck.Count;
        System.Random rand = new System.Random();
        while (n > 1) 
        {
            int k = (rand.Next(0, n) % n);
            n--;
            int value = WildDeck[k];
            WildDeck[k] = WildDeck[n];
            WildDeck[n] = value;
        }
        //renders all the players cards in Wild mode
        for(int i = 0; i < StartingHandSize; i++)     
        {
            GameObject NewCard = Instantiate(EmptyCard);
            NewCard.GetComponent<SpriteRenderer>().sprite = NewCard.GetComponent<SetCardType>().CardList[WildDeck[i]]; 
            NewCard.GetComponent<Transform>().Translate(i*4-10, -10, 0);
            DrawCounter++;
        }
        //renders all the computers cards
        for(int i = 0; i < StartingHandSize; i++)      
        {
            GameObject NewCard = Instantiate(EmptyCard);
            NewCard.GetComponent<SpriteRenderer>().sprite = NewCard.GetComponent<SetCardType>().CardList[WildDeck[i+6]]; 
            NewCard.GetComponent<Transform>().Translate(i*4-10, 10, 0);
            DrawCounter++;
        }
        Debug.Log(DrawCounter);
        //render RecyclePile
        GameObject NewRecyclePile = Instantiate(RecyclePile);
        NewRecyclePile.GetComponent<Transform>().position = new Vector3( -5, 0, 0);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
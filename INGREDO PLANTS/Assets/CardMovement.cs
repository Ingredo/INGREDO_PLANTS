using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 OriginalPosition;
    private Vector3 RecyclePosition;
    private bool isOnRecyclePile;
    private SpriteRenderer sprnd;
    //private Vector3 TempPosition;
    private Color startColor;
    // Start is called before the first frame update
    void Start()
    {
        RecyclePosition = new Vector3(-5, -1, 0);
        isOnRecyclePile = false;
        Debug.Log(gameObject.name);
        sprnd = GetComponent<SpriteRenderer>();
        startColor = sprnd.color;
    }

    // Update is called once per frame

    void Update()
    {
        //gameObject.GetComponent<Transform>().Translate(Vector3.left * Time.deltaTime); makes the cards move left 
    }

    void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); //converting a vector 3 in game space to an x,y pos on screen
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        OriginalPosition = gameObject.transform.position;
    }

     void OnMouseDrag()
    {
     Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
     Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
     transform.position = curPosition;
    }
    void OnMouseUp()
    {
        Debug.Log("MouseUp");
        Debug.Log(isOnRecyclePile);
        if (isOnRecyclePile)
        {
            transform.position = RecyclePosition;
        }
        else
        {
            transform.position = OriginalPosition;
        }
    }
            void OnCollisionEnter2D(Collision2D collision)   
    {
        //Debug.Log("Collision Detected: 1");
        //If the object hit is the RecyclePile
         if (collision.gameObject.tag == "RecyclePile")
            {
                isOnRecyclePile = true;
                //Debug.Log(true);
            }  
    
    }
                void OnCollisionExit2D(Collision2D collision)   
    {
        //Debug.Log("Collision Detected: 1");
        //If the object hit is the RecyclePile
         if (collision.gameObject.tag == "RecyclePile")
            {
                isOnRecyclePile = false;
                //Debug.Log(true);
            }  
    
    }
}

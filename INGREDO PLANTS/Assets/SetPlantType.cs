using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlantType : MonoBehaviour
// This class contains a list of plant sprites 
{
    // Start is called before the first frame update
    public List<Sprite> PlantList = new List<Sprite>();
    public int MaxPlants;

    void Start()
    {
        int MaxPlants = PlantList.Count;
        Debug.Log(MaxPlants);
        //gameObject.GetComponent<SpriteRenderer>().sprite = PlantList[Random.Range(1, MaxPlants)];
    }

    // Update is called once per frame
    void Update()
    {

    }
}

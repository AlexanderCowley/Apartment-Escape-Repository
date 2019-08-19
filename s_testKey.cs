using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_testKey : MonoBehaviour
{
    //This script is meant to emulate a key being taken and being able to unlock a specfied door with it
    public s_itemProperties i_Properties;
    public bool hasKey;
    public Items item;
    public Text text_itemMessage;
    public bool ItemUse;
    public GameObject Key;
    bool keyPickedUp;
    public Text text_interactionMessage;
    public Text text_stateChangeMessage;

    // Use this for initialization
    void Start() //find the item property script
    {
        i_Properties = GetComponent<s_itemProperties>();
    }

    private void OnTriggerStay(Collider other) //If the item is picked up deactivate the text
    {
        if (ItemUse == true)
        {
            text_interactionMessage.gameObject.SetActive(false);
        }
    }

    public void pickUpItem() //states haskey as true, makes the mesh disappear and enables the player to unlock certain doors
    {
        if (keyPickedUp == false)
        {
            keyPickedUp = !keyPickedUp;
            hasKey = true; // player has key
            ItemUse = !ItemUse;
            Key.SetActive(false); //Gameobject is disabled
            text_itemMessage.text = item.stateChangeMessage.ToString(); // turns item message text into state change message text
            text_stateChangeMessage.text = item.stateChangeMessage.ToString();
            i_Properties.StartCoroutine("textFade");
        }

    }

    private void Update()
    {

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_itemProperties : MonoBehaviour
{
    //This script is used to centralize common item properties and searches for the correct item script to trigger
    public Items item;
    public s_doorLocked sDoorLocked;
    public s_Key sKey;
    public s_exit sExit;
    public s_Door sDoor;
    public Text text_stateChangeMessage;
    public Text text_interactionMessage;
    bool playerRange;

    // Start is called before the first frame update
    //Gets the appropriate scripts
    void Start() 
    {
        sDoorLocked = GetComponent<s_doorLocked>();
        sDoor = GetComponent<s_Door>();
        sKey = GetComponent<s_Key>();
        sExit = GetComponent<s_exit>();
    }

    //checks if the player is in range of an item and displays to text to indicate that it can be interacted with
    private void OnTriggerEnter(Collider collider)
    {
        //checks if the player has entered an item's box collider
        if (collider.gameObject.name == "Player")
            playerRange = true;
        //Translates string into interaction message text
        text_interactionMessage.text = item.interactionMessage.ToString();
        text_interactionMessage.gameObject.SetActive(true);
    }

    //checks if the player is out of range of object and diables interaction text
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Player")
            playerRange = false;
        text_interactionMessage.gameObject.SetActive(false);
    }

    //Activates state change message, fades the text over the span of one second and then deactivates the text
    IEnumerator textFade()
    {
        text_stateChangeMessage.gameObject.SetActive(true);
        text_stateChangeMessage.CrossFadeAlpha(0, 1.0f, false);
        yield return new WaitForSeconds(1.0f);
        text_stateChangeMessage.gameObject.SetActive(false);
    }

    //Updates item message to only be active when the item has not be picked up
    void UpdateMessage()
    {
        if (sKey.ItemUse == false)
            text_interactionMessage.gameObject.SetActive(true);
        else if(sKey.ItemUse == true)
            text_interactionMessage.gameObject.SetActive(false);
    }
    //Searches for the correct script based on the Items Scriptable Object's ItemTypes enum values
    public void UseItem()
    {
        switch (item.Itemtypes)
        {
            case Items.itemTypes.doors:
                sDoor.DoorState();
                break;

            case Items.itemTypes.lockedDoors:
                sDoorLocked.lockedDoor();
                break;

            case Items.itemTypes.keys:
                sKey.pickUpKey();
                //Updates interaction message visibility
                UpdateMessage();
                break;

            case Items.itemTypes.exit:
                sExit.ExitGame();
                break;

            //Checks for improper item type assignment or error
            default:
                Debug.Log("No Item Type Found!");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerRange == true)
        {
            UseItem();
        }
    }
}

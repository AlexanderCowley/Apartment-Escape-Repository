using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_doorLocked : MonoBehaviour
{
    //This script is meant to prevent locked doors from being opened without a key
    public Items item;
    public s_itemProperties i_Properties;
    public Animator _animator;
    public GameObject Key;
    public Text text_stateChangeMessage;
    public Text text_interactionMessage;
    public bool openDoor;
    public bool hasKey;
    bool firstOpened = true;
    string i_Message;

    //Updates door message method every few frames the player is in the item's box collider
    private void OnTriggerStay(Collider other)
    {
        UpdateDoorMessage();
    }

    //Is used to determine whether the player can unlock and open the door
    public void lockedDoor()
    {
        //Accesses door animation
        _animator = GetComponentInChildren<Animator>();
        //Accesses bool that dettermines whether the player has the key
        hasKey = Key.GetComponentInParent<s_Key>().hasKey;
        if(hasKey == true)
        {
            //Checks if the player has opened the locked door before
            if (firstOpened == true)
            {
                firstOpened = false;
                //Sets state change message to: Unlocked!
                text_stateChangeMessage.text = item.itemMessage.ToString();
                i_Properties.StartCoroutine("textFade");
            }

        openDoor = !openDoor;
        //animation for door trigger
        _animator.SetBool("open", openDoor);
        UpdateDoorMessage();

        }
        else
        {
            //state change message is set to: Locked!
            text_stateChangeMessage.text = item.stateChangeMessage.ToString();
            i_Properties.StartCoroutine("textFade");
        }
    }

    //Updates interaction message based on open door state
    public void UpdateDoorMessage()
    {
        if (openDoor == false)
            i_Message = "Open Door?";
        else
            i_Message = "Close Door?";
        //Translates string into interaction message text
        text_interactionMessage.text = i_Message.ToString();
        text_interactionMessage.gameObject.SetActive(true);
    }

}

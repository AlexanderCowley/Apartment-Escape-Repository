using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class s_Door : MonoBehaviour
{
    //Animator holds the door animation
    public Animator _animator;
    //Text that is displayed when the player can interact with an item
    public Text text_interactionMessage;
    public bool openDoor; 

    // Start is called before the first frame update
    void Start()
    {
        //accesses Unity animator component to change door animation
        _animator = GetComponentInChildren<Animator>();
    }

    //Updates door message method every few frames the player is in the item's box collider
    private void OnTriggerStay(Collider other)
    {
        UpdateDoorMessage();
    }

    //Switches Door state from open to close
    public void DoorState()
    {
        openDoor = !openDoor;
        //Switches animation state using bool
        _animator.SetBool("open", openDoor);
        //Updates text based on door state
        UpdateDoorMessage();
    }

    //Updates interaction message text based on door state
    public void UpdateDoorMessage()
    {
        string i_Message;
        if (openDoor == false)
            i_Message = "Open Door?";
        else
            i_Message = "Close Door?";
        //Translates string into interaction message text
        text_interactionMessage.text = i_Message.ToString();
        text_interactionMessage.gameObject.SetActive(true);
    }

}

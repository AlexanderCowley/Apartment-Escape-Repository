using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[CreateAssetMenu(fileName ="Items", menuName = "Items")]
public class Items : ScriptableObject {
    //This script stores item data such as strings and enums using Unity's Scriptable Objects
    public string itemName;
    public string itemMessage;
    public string stateChangeMessage;
    public string interactionMessage;
    //uses enumeration to seperate items by type
    public enum itemTypes { keys, doors, lockedDoors, exit}
    public itemTypes Itemtypes;

}

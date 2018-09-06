using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[2];


    public void Add_item(GameObject item) {

        bool item_added = false;

        //find firs open slot
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null) {
                inventory[i] = item;
                Debug.Log(item.name + " was added");
                item_added = true;
                //do something to obj
                item.SendMessage("Do_interaction");
                break;
            }
        }

        //inventory full
        if (item_added == false) {
            Debug.Log("inventory is full");
        }

    }

    public bool Find_item(GameObject item) {

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item) {
                //found item, esle not found
                return true;
            }
        }
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_interacting : MonoBehaviour {

    public GameObject current_inter_object = null;
    public Interaction_object current_inter_obj_script = null;
    public Inventory inventory;

    void Update() {

        if (Input.GetButtonDown("Interact") && current_inter_object) {
            //check obj to be stored in iventory
            if (current_inter_obj_script.inventory) {
                inventory.Add_item(current_inter_object);
                current_inter_object = null;
            }
            //if door
            if (current_inter_obj_script.openable) {
                //if locked
                if (current_inter_obj_script.locked)
                {
                    //if have key, search in inventory
                    if (inventory.Find_item(current_inter_obj_script.item_needed))
                    {
                        //found item needed
                        current_inter_obj_script.locked = false;
                        Debug.Log(current_inter_object.name + " was unlocked");
                    }
                    else
                    {
                        Debug.Log(current_inter_object.name + " was not unlocked");
                    }
                }
                else {
                    // object not locked
                    Debug.Log(current_inter_object.name + " is openable");
                    //animate script
                    //current_inter_obj_script.Open();
                    //for now mame door invisible
                    current_inter_obj_script.Do_interaction();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("interact_object")) {
            Debug.Log(other.name);
            current_inter_object = other.gameObject;
            current_inter_obj_script = current_inter_object.GetComponent<Interaction_object>();
        }
    }

    void OnTriggerExit2D(Collider2D other) {

        if (other.CompareTag("interact_object"))
        {
            if (other.gameObject == current_inter_object) {
                current_inter_object = null;

            }

        }

    }
     
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_object : MonoBehaviour {

    public bool inventory; //if true, can be stored in inventory

    public void Do_interaction() {

        //pick up and put into inventory
        gameObject.SetActive(false);

    }  
		
	
}

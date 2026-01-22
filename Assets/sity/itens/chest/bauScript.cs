using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
	This script came with the chest asset that was inserted in my project

	Author: Leandro Melchior (Publisher/User on Unity Asset Store)
	Location: https://assetstore.unity.com/packages/3d/props/steampunk-chest-69723#content
	Accessed: 16/01/2026
*/
//However there are various points that I have modified this script to suit the game which are clearly indicated
public class bauScript : MonoBehaviour {

	//I removed this variable from the original script as it was redundant data for my game
	//public string player = "Player";
	public float velocity = 10.0f;
	bool abrir = false;

	GameObject alvo;
	bool cheio = true;
	public GameObject target;
	public List<GameObject> Contents;

	//I added the following fields to link other game objects into this script
	public GameObject player;
	public GameObject key;
	public GameObject pear;
	public GameObject hintBox;

	//I added these fields for the script to be able to tell if various functions can happen
	//bool for if the chest can be opened
	bool canOpenChest=false;
	//bool for if the pick up hint can be called
	bool pickUpHintCalled = false;
	//bool for if the game has started / instruction dialogue has finished
	bool gameplayStarted;
	//my modification ends

	//these values were in the original script but are not used for this project
	//rotatação max  -60 -900 -900
	//0, -720, -720

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//I added this so the script could get information on whether the game has started or not
		gameplayStarted = player.GetComponent<PlayerHealthScript>().enabled;
		if (gameplayStarted)
		{
			//if game has started and E is clicked chest can be opened
				if(Input.GetKey(KeyCode.E))
			{
				canOpenChest=true;
			}
			else
			{
				canOpenChest = false;
			}

		//my modification ends	

			if (abrir) {
				
				if (this.transform.rotation.x > -0.9) {
					
					this.transform.Rotate (new Vector3 (-velocity * Time.deltaTime * 2, 0.0f, 0.0f));
					if(this.transform.rotation.x < -0.45 && cheio == true){
						liberar ();
						cheio = false;
						
					}
				}
				//I added this so once the chest has fully opened the pickup hint can be shown
				if(this.transform.rotation.x <= -0.9 && pickUpHintCalled==false)
				{
					hintBox.SetActive(true);
					hintBox.GetComponent<HintUpdateScript>().PickUpItems();
					pickUpHintCalled = true;
				}

				//I added this so that once P was clicked the items were picked up, pear increases health and the hint is cleared

				if (Input.GetKeyDown(KeyCode.P))
				{
					key.gameObject.SetActive(false);
					
					player.GetComponent<PlayerHealthScript>().playerHealth += 5;
					pear.gameObject.SetActive(false);
					hintBox.GetComponent<HintUpdateScript>().ClearHint();

				}
				//my modification ends
			} else {
				if (this.transform.rotation.x < 0) {
					this.transform.Rotate (new Vector3 (velocity * Time.deltaTime * 2 , 0.0f, 0.0f));

				} 
			}
		}

		
	
	}


	void OnTriggerStay(Collider other) {
		//I added these if statements so the script could tell if the gameplay has started
		if (gameplayStarted)
		{
			//and if the chest is closed when the player fires the trigger
			if(other.gameObject.name == "FirstPersonController"&&abrir==false)
			{
			//My modification ends
				if (alvo == null) {
					Vector3 pos = this.transform.position;
					pos.y += 0.5f;
					pos.z += 0.25f;
					alvo = Instantiate (target, pos, Quaternion.identity) as GameObject;
					//I added these 2 lines of code to enable the open chest hint to appear
					hintBox.SetActive(true);
					hintBox.GetComponent<HintUpdateScript>().OpenChest();
					//my modification ends
				}
				// I added this if statement to check if the chest can open - i.e the E key is pressed
				if (canOpenChest)
				{
				//my modification ends
					abrir = true;
					Destroy (alvo.gameObject);
					//I added this line of code to clear and hide the hintbox
					hintBox.GetComponent<HintUpdateScript>().ClearHint();
				}
				
				
			}
		}
		//my modification ends
	}

	void OnTriggerExit(Collider other) {

		
		//I added this if statement so the script could tell if the gameplay has started
		if (gameplayStarted)
		{
			//I added this line of code to clear and hide the hintbox
			hintBox.GetComponent<HintUpdateScript>().ClearHint();
			//my modification ends

			Destroy (alvo.gameObject);
			//I added this line of code to set the ability to open chest to false
			canOpenChest = false;
		}
		//my modification ends
		
	}


	public void liberar(){
		//I added this line of code to clear and hide the hintbox
		hintBox.GetComponent<HintUpdateScript>().ClearHint();
		//my modification ends

		Vector3 pos = this.transform.position;
		//pos.x = 0;
		pos.y += 0.4f;
		pos.z += 0.4f;

		for (int i = 0; i < Contents.Count; i++) {
			GameObject premio = Instantiate (Contents[i], pos, Quaternion.identity) as GameObject;

			Rigidbody rb = premio.GetComponent<Rigidbody>();
			if (rb == null) {
				rb = premio.AddComponent<Rigidbody> ();
			}
			rb.AddForce (new Vector3(0,1,1));
		}
	}

}	

	

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bauScript : MonoBehaviour {


	//public string player = "Player";
	public float velocity = 10.0f;

	public GameObject target;
	public List<GameObject> Contents;
	//modification by me
	public GameObject player;
	public GameObject key;
	public GameObject pear;
	public GameObject hintBox;

	bool abrir = false;

	GameObject alvo;
	bool cheio = true;
	bool canOpenChest=false;
	bool pickUpHintCalled = false;
	bool gameplayStarted;
	//rotatação max  -60 -900 -900
	//0, -720, -720

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameplayStarted = player.GetComponent<PlayerHealthScript>().enabled;
		if (gameplayStarted)
		{
				if(Input.GetKey(KeyCode.E))
			{
				canOpenChest=true;
			}
			else
			{
				canOpenChest = false;
			}

			

			if (abrir) {
				
				if (this.transform.rotation.x > -0.9) {
					
					this.transform.Rotate (new Vector3 (-velocity * Time.deltaTime * 2, 0.0f, 0.0f));
					if(this.transform.rotation.x < -0.45 && cheio == true){
						liberar ();
						cheio = false;
						
					}
				}
				if(this.transform.rotation.x <= -0.9 && pickUpHintCalled==false)
				{
					hintBox.SetActive(true);
					hintBox.GetComponent<HintUpdateScript>().PickUpItems();
					pickUpHintCalled = true;
				}



				
				//modification by Me

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

		if (gameplayStarted)
		{
				if(other.gameObject.name == "FirstPersonController"&&abrir==false)
			{
				if (alvo == null) {
				Vector3 pos = this.transform.position;
				pos.y += 0.5f;
				pos.z += 0.25f;
				alvo = Instantiate (target, pos, Quaternion.identity) as GameObject;
				}

				if (canOpenChest==true)
				{
						abrir = true;
						Destroy (alvo.gameObject);
				}
				else
				{
					//enable hint script
					hintBox.SetActive(true);
					hintBox.GetComponent<HintUpdateScript>().OpenChest();
				}
			}
		}

		
		



	}

	void OnTriggerExit(Collider other) {

		
		
		if (gameplayStarted)
		{
			hintBox.GetComponent<HintUpdateScript>().ClearHint();
			Destroy (alvo.gameObject);
			canOpenChest = false;
		}
		
		
	}


	public void liberar(){
		hintBox.GetComponent<HintUpdateScript>().ClearHint();
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

	

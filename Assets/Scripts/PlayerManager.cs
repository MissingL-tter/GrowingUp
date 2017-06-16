using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	//Dialog Requirments
	public GameObject npcInRange = null;
	public bool inDialogue;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (!inDialogue) {

			this.transform.Translate(Input.GetAxis("Horizontal") * 10 * Time.deltaTime,0,0);

			if (npcInRange && Input.GetButtonDown("Submit")) {
				inDialogue = true;
				npcInRange.GetComponent<NPCBehaviour>().dialogueUtility.InitDialogue();
			}

		}

	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag("NPC")) {
			other.GetComponent<NPCBehaviour>().dialogueUtility.ShowDialogueIcon(true);
			npcInRange = other.gameObject;
		}

	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.CompareTag("NPC")) {
			other.GetComponent<NPCBehaviour>().dialogueUtility.ShowDialogueIcon(false);
			npcInRange = null;
		}
		
	}
	
}

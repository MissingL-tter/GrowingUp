using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour {

	//Static reference to an instance of this class
	//Storage unit for variables needed globally
	public static Global reference;

	//Player Reference Variable
	public GameObject player;
	public PlayerManager playerManager;
	public GameObject playerDialogueCanvas;
	public Text playerText;
	
	//UI Component Variables
	public GameObject guiButtonA;

	void Awake () {

		if (reference == null) {
			DontDestroyOnLoad(gameObject);
			reference = this;
		} else if (reference != this) {
			Destroy(gameObject);
		}

		playerManager = player.GetComponent<PlayerManager>();
		playerDialogueCanvas = player.transform.Find("DialogueCanvas").gameObject;
		playerText = playerDialogueCanvas.transform.Find("Text").GetComponent<Text>();
		
	}

}

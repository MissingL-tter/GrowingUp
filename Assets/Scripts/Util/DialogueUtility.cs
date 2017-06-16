using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUtility : MonoBehaviour {

	//Player References
	PlayerManager playerManager;
	GameObject playerDialogueCanvas;
	Text playerText;

	//Dialogue UI Gameobjects
	GameObject dialogueIcon;
	GameObject NPCdialogueCanvas;
	Text NPCtext;

	//Appropriate dialogue from file
	public TextAsset[] dialogue;
	string[] lines;
	int position;
	int completedDialogues;

	void Start () {

		playerManager = Global.reference.playerManager;
		playerDialogueCanvas = Global.reference.playerDialogueCanvas;
		playerText = Global.reference.playerText;

		NPCdialogueCanvas = gameObject.transform.Find("DialogueCanvas").gameObject;
		NPCtext = NPCdialogueCanvas.transform.Find("Text").GetComponent<Text>();
		dialogueIcon = gameObject.transform.Find("DialogueIcon").gameObject;

	}

	void Update () {

		if (playerManager.npcInRange == gameObject && playerManager.inDialogue == true) {

			string line = null;
			if (position < lines.Length) {
				line = lines[position];
			}

			if (line != null) {

				if (Input.GetButtonDown("Submit")) {
					string speaker = line.Split(':')[0];
					string text = line.Split(':')[1];

					if (speaker == "Player") {
						NPCdialogueCanvas.SetActive(false);
						playerDialogueCanvas.SetActive(true);
						playerText.text = text;
						//print("Me: " + text);
					} else {
						playerDialogueCanvas.SetActive(false);
						NPCdialogueCanvas.SetActive(true);
						NPCtext.text = text;
						//print(speaker + ": " + text);
					}

					position++;
				}
			} else {

				if (Input.GetButtonDown("Submit")) {
					NPCdialogueCanvas.SetActive(false);
					playerDialogueCanvas.SetActive(false);
					playerManager.inDialogue = false;
					completedDialogues++;
					position = 0;
				}

			}
		}

	}

	//Helper method to make calls RunConversation() from outside this class more concise
	public void InitDialogue() {
		lines = dialogue[completedDialogues].text.Split('\n');
	}

	//Shows the icon on this NPC based on referenced boolean
	public void ShowDialogueIcon (bool state) {
		dialogueIcon.SetActive(state);
	}

}
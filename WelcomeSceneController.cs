using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WelcomeSceneController : MonoBehaviour {
    public Button confirmButton;
    public InputField nameInputField;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (nameInputField.text.Length == 0) {
            confirmButton.interactable = false;
        } else {
            confirmButton.interactable = true;
        }
	}

    public void OnClickContinue () {
        PlayerPrefs.SetString("playername", nameInputField.text);

        // Load the menu scene
        SceneManager.LoadScene("MenuScene");
    }
}

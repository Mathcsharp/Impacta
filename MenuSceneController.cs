using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour {
    public Text titleText;

	// Use this for initialization

	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickOperation (string operation) {
        PlayerPrefs.SetString("operation", operation);

        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickQuit () {
        SceneManager.LoadScene("Platform");
    }
}

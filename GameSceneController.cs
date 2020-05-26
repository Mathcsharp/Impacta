using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour {
    public Text titleText;

    public Text questionText;
    public Button[] answerButtons;

    public Sprite defaultButtonSprite;
    public Sprite correctButtonSprite;
    public Sprite wrongButtonSprite;

    private string operation;
    private bool isReinforcing;
    private int number1;
    private int number2;
    private int answer;

	// Use this for initialization
	void Start () {
        // Get the current operation
        operation = PlayerPrefs.GetString("operation");

        // Check if we are in the reinforcement mode
        isReinforcing = operation == "reinforcement";

        // Ensure the operations are being saved
        string playerName = PlayerPrefs.GetString("playername");
        if (!PlayerPrefs.HasKey(playerName + ".addition.correct")) PlayerPrefs.SetInt(playerName + ".addition.correct", 0);
        if (!PlayerPrefs.HasKey(playerName + ".subtraction.correct")) PlayerPrefs.SetInt(playerName + ".subtraction.correct", 0);
        if (!PlayerPrefs.HasKey(playerName + ".multiplication.correct")) PlayerPrefs.SetInt(playerName + ".multiplication.correct", 0);
        if (!PlayerPrefs.HasKey(playerName + ".division.correct")) PlayerPrefs.SetInt(playerName + ".division.correct", 0);

        LoadQuestion();
	}

    void LoadQuestion () {
        if (isReinforcing) {
            int leastAnswers = int.MaxValue;
            string leastAnsweredOperation = "Adição";

            string playerName = PlayerPrefs.GetString("playername");
            int additionCorrect = PlayerPrefs.GetInt(playerName + "." + "addition" + ".correct");
            int subtractionCorrect = PlayerPrefs.GetInt(playerName + "." + "subtraction" + ".correct");
            int multiplicationCorrect = PlayerPrefs.GetInt(playerName + "." + "multiplication" + ".correct");
            int divisionCorrect = PlayerPrefs.GetInt(playerName + "." + "division" + ".correct");

            if (additionCorrect < leastAnswers)
            {
                leastAnswers = additionCorrect;
                leastAnsweredOperation = "Adição";
            }
            if (subtractionCorrect < leastAnswers)
            {
                leastAnswers = subtractionCorrect;
                leastAnsweredOperation = "Subtração";
            }
            if (multiplicationCorrect < leastAnswers)
            {
                leastAnswers = multiplicationCorrect;
                leastAnsweredOperation = "Multiplicação";
            }
            if (divisionCorrect < leastAnswers)
            {
                leastAnswers = divisionCorrect;
                leastAnsweredOperation = "Divisão";
            }

            operation = leastAnsweredOperation;
        }

        titleText.text = operation.Substring(0, 1).ToUpper() + operation.Substring(1);

        LoadOperation();
        UpdatePuzzle();
    }

    public void OnClickQuit () {
        SceneManager.LoadScene("MenuScene");
    }

    public void OnClickAnswer (int answerIndex) {
        Button selectedButton = answerButtons[answerIndex];
        int playerAnswer = int.Parse(selectedButton.GetComponentInChildren<Text>().text);

        // Set the wrong answer sprite
        bool isCorrect = playerAnswer == answer;
        if (!isCorrect) {
            selectedButton.GetComponent<Image>().overrideSprite = wrongButtonSprite;
        } else {
            // Increase the correct count
            string playerName = PlayerPrefs.GetString("playername");
            PlayerPrefs.SetInt(playerName + "." + operation + ".correct", PlayerPrefs.GetInt(playerName + "." + operation + ".correct") + 1);
        }

        // Set the correct sprite answer
        for (int i = 0; i < answerButtons.Length; i++) {
            Button button = answerButtons[i];
            if (int.Parse(button.GetComponentInChildren<Text>().text) == answer) {
                button.GetComponent<Image>().overrideSprite = correctButtonSprite;
            }

            // Disable all the buttons
            button.interactable = false;
        }

        // Wait and load another question
        Invoke("LoadQuestion", 3);
    }

    void LoadOperation () {
        for (int i = 0; i < answerButtons.Length; i++) {
            answerButtons[i].GetComponent<Image>().overrideSprite = defaultButtonSprite;
            answerButtons[i].interactable = true;
        }

        if (operation == "Adição") LoadAddition();
        else if (operation == "Subtração") LoadSubtraction();
        else if (operation == "Multiplicação") LoadMultiplication();
        else if (operation == "Divisão") LoadDivision();
    }

    void LoadAddition () {
        number1 = Random.Range(1, 10);
        number2 = Random.Range(1, 10);
        answer = number1 + number2;
    }

    void LoadSubtraction () {
        number2 = Random.Range(1, 5);
        number1 = Random.Range(number2, 10);
        answer = number1 - number2;
    }

    void LoadMultiplication () {
        number1 = Random.Range(1, 5);
        number2 = Random.Range(1, 5);
        answer = number1 * number2;
    }

    void LoadDivision () {
        answer = Random.Range(2, 6);
        number2 = Random.Range(3, 6);
        number1 = answer * number2;
    }

    void UpdatePuzzle () {
        string operationSign = "";
        if (operation == "Adição") operationSign = "+";
        else if (operation == "Subtração") operationSign = "-";
        else if (operation == "Multiplicação") operationSign = "x";
        else if (operation == "Divisão") operationSign = "/";

        // Set the question
        questionText.text = number1 + " " + operationSign + " " + number2;

        // Set the answers
        List<int> answers = new List<int>() { answer, answer - 1, answer + 1, answer + 2 };
        for (int i = 0; i < answerButtons.Length; i++) {
            Button button = answerButtons[i];

            int randomIndex = Random.Range(0, answers.Count);
            button.GetComponentInChildren<Text>().text = answers[randomIndex].ToString();
            answers.RemoveAt(randomIndex);
        }
    }
}

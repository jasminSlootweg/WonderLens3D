using UnityEngine;
using TMPro;  // Required for TMP_InputField and TMP_Text
using UnityEngine.UI;  // Required for Button, etc.

public class SpellingGame : MonoBehaviour
{
    public TMP_Text sentenceDisplay;  // The UI TextMeshPro Text to show the sentence
    public TMP_InputField userInput;  // The UI InputField to type in the answer (using TMP_InputField now)
    public Button submitButton;   // The Button to submit the answer
    public Button nextButton;     // The Button to go to the next page
    public AutoFlip pageFlipper;  // The AutoFlip script to control the book

    private int currentSentenceIndex = 0;
    private int currentPage = 1;

    // Sample sentences for the story
    private string[][] storySentences = new string[][]
    {
        new string[] { "Little Red Riding Hood" },
        new string[] { "Once upon a time there was a girl called Little Red Riding Hood.", "She lived with her mother in a village near a forest." },
        new string[] { "One day, Little Red Riding Hood went to visit her grandmother.", "She took a basket of food with her." },
        new string[] { "On her way, Little Red Riding Hood met a wolf.", "\"Hello,\" said the wolf.", "\"Where are you going?\"", "\"I'm going to visit my grandmother who lives in the forest,\" explained Little Red Riding Hood." },
        new string[] { "The wolf ran to her grandmother's house.", "He went inside and locked her in the wardrobe!", "He put on her nightgown and got into her bed." }
    };

    void Awake()
    {
        // Automatically assign references to UI elements
        sentenceDisplay = GameObject.Find("sentenceDisplay").GetComponent<TMP_Text>();  // Use TMP_Text for TextMeshPro
        userInput = GameObject.Find("userInput").GetComponent<TMP_InputField>();  // Make sure to use TMP_InputField
        submitButton = GameObject.Find("submitButton").GetComponent<Button>();
        nextButton = GameObject.Find("nextButton").GetComponent<Button>();

        // Get the AutoFlip script attached to the book GameObject (using the new method)
        pageFlipper = UnityEngine.Object.FindFirstObjectByType<AutoFlip>();

        // Hide the next button initially
        nextButton.gameObject.SetActive(false);
    }

    void Start()
    {
        // Load the first sentence when the game starts
        LoadSentence();

        // Add listener to the submit button
        submitButton.onClick.AddListener(CheckAnswer);

        // Add listener to the next button
        nextButton.onClick.AddListener(NextPage);
    }

    public void LoadSentence()
    {
        // Load the current sentence based on the current page and sentence index
        if (currentSentenceIndex < storySentences[currentPage].Length)
        {
            sentenceDisplay.text = storySentences[currentPage][currentSentenceIndex];
        }
    }

    public void CheckAnswer()
    {
        if (userInput.text.Trim() == sentenceDisplay.text)
        {
            // Correct answer
            currentSentenceIndex++;
            if (currentSentenceIndex < storySentences[currentPage].Length)
            {
                LoadSentence();  // Load next sentence
            }
            else
            {
                // Show the next button if all sentences on the page are done
                nextButton.gameObject.SetActive(true);
            }
        }
        else
        {
            // Incorrect answer, reset input field
            userInput.text = "";
        }
    }

    public void NextPage()
    {
        // Flip to the next page using AutoFlip
        pageFlipper.FlipRightPage();

        // Reset for the next page
        currentPage++;
        currentSentenceIndex = 0;
        LoadSentence();

        // Hide the next button again
        nextButton.gameObject.SetActive(false);
    }
}

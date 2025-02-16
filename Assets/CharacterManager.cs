using UnityEngine;
using UnityEngine.SceneManagement;  // For scene management

public class CharacterManager : MonoBehaviour
{
    // Reference to the button prefab (you can assign this in the Inspector)
    public GameObject characterPrefab; 

    // Static reference to store the selected button
    public static GameObject selectedCharacterPrefab;

    // Function to set the button prefab and load the new scene
    public void OnButtonClicked()
    {
        // Store the reference to the button prefab in the static variable
        selectedCharacterPrefab = characterPrefab;
        
        // Load the second scene
        SceneManager.LoadScene("BookCarousel");
    }
}




using UnityEngine;
using UnityEngine.SceneManagement;  // For scene management

public class CharacterManager : MonoBehaviour
{
    // Reference to the button prefab (you can assign this in the Inspector)
    public GameObject characterPrefab; 
    public Sprite backgroundSprite; // Reference to the background sprite (PNG)

    // Static references to store the selected character and background
    public static GameObject selectedCharacterPrefab;
    public static Sprite selectedBackgroundSprite;

    // Function to set the button prefab and load the new scene
    public void OnButtonClicked()
{
    // Instantiate the character prefab at runtime in the scene
    GameObject characterInstance = Instantiate(characterPrefab, Vector3.zero, Quaternion.identity);

    // Store the background sprite for the selected character
    selectedCharacterPrefab = characterPrefab;
    selectedBackgroundSprite = backgroundSprite;

    // Load the next scene
    SceneManager.LoadScene("BookCarousel");
}

}

using UnityEngine;
using UnityEngine.UI;

public class DisplayButton : MonoBehaviour
{
    // Reference to the parent UI container where the image will be displayed
    public Transform imageContainer;

    void Start()
    {
        // Check if a button prefab has been selected
        if (CharacterManager.selectedCharacterPrefab != null)
        {
            // Get the Image component from the selected button prefab
            Image buttonImage = CharacterManager.selectedCharacterPrefab.GetComponent<Image>();

            if (buttonImage != null)
            {
                // Instantiate a new GameObject to hold the image (does not copy the button component itself)
                GameObject imageObject = new GameObject("ButtonImage");

                // Add an Image component to this new GameObject
                Image newImage = imageObject.AddComponent<Image>();

                // Set the sprite to be the same as the prefab button's image
                newImage.sprite = buttonImage.sprite;

                // Ensure that the new Image component does not use any default image (clear any source image)
                newImage.preserveAspect = buttonImage.preserveAspect; // Optional: match aspect ratio from prefab
                newImage.type = buttonImage.type; // Optional: match image type (simple, sliced, etc.)

                // Optionally, copy other properties like color from the original button's image
                newImage.color = buttonImage.color;

                // Set the instantiated image as a child of the image container
                imageObject.transform.SetParent(imageContainer, false); // "false" to maintain local position/scale

                Debug.Log("Instantiated image sprite: " + newImage.sprite.name);
            }
            else
            {
                Debug.LogWarning("No Image component found on the button prefab.");
            }
        }
    }
}





using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    // Reference to the SpriteRenderer that will display the background image
    public SpriteRenderer backgroundRenderer;

    void Start()
    {
        // Ensure the selected background sprite is not null
        if (CharacterManager.selectedBackgroundSprite != null)
        {
            // Set the background sprite to the selected sprite
            backgroundRenderer.sprite = CharacterManager.selectedBackgroundSprite;
        }
        else
        {
            // Optionally, you could set a default background here if no sprite is selected
            Debug.LogWarning("No background sprite selected! Setting a default background.");
            // backgroundRenderer.sprite = defaultBackgroundSprite;
        }
    }
}

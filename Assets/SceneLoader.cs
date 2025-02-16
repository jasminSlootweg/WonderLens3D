using UnityEngine;
using UnityEngine.SceneManagement;  // Import the SceneManagement namespace

public class SceneLoader : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);  // Load the scene by name
    }
}


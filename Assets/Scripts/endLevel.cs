using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endLevel : MonoBehaviour
{

    // The name of the next scene to load
    public string nextSceneName;


    public string showMessage;

    public GameObject messageText;
    // Drag your Text hodler element here in the Inspector

    [SerializeField] private Text childText;

    // Function to set the message text
    public void ShowMessage(string message)
    {

        childText.text = message;

        //Show message
        messageText.SetActive(true);
    }

    // Function to hide the message text
    public void HideMessage()
    {
        messageText.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the object entering the trigger is the player
        if (other.gameObject.tag == "Player")
        {
            // display win message
            ShowMessage(showMessage);
            // Delay for visual effect (optional)
            Invoke("LoadNextLevel", 2f);
        }
    }

    // Function to load the next scene
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }

}
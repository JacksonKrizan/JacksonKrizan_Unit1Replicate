using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DestoryTextbox : MonoBehaviour
{
    public GameObject bomb;
    //public InputField myInputField;
    public TMP_InputField myInputField;
    private string inputText;
    public AudioSource explode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        explode = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    string inputText = myInputField.text;

    if (inputText == "Jarvis Blow Up")
    {
        DestroyObject(bomb);
        explode.Play();
        Debug.Log("blew up");
        // Perform actions when the condition is met
    }
    else if (inputText.ToLower() == "exit") // Case-insensitive comparison
    {
        Debug.Log("Exiting application...");
        Application.Quit(); // Example action
    }
    else
    {
        Debug.Log("Input was: " + inputText);
    }

    void DestroyObject(GameObject bomb)
    {
        Destroy(bomb);
    }


    }

}

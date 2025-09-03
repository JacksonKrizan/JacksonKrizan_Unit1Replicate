using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DestoryTextbox : MonoBehaviour
{
    public GameObject bomb;

    public TMP_InputField myInputField;
    public TMP_Text numbersCounted;
    
    public AudioSource explode;

    public int millionForDumbies;
    public bool millionOn;
    private string inputText;
    private string millionFor;

    public GameObject bombAnimation; // Add this line

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        explode = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    string inputText = myInputField.text;

    if (inputText == "Count to a million")
    {
        millionOn = true;
    }

    if (millionOn == true)
    {
        millionFor = millionForDumbies.ToString();
        millionForDumbies = millionForDumbies + 1;
        Debug.Log(millionForDumbies);
        numbersCounted.text = millionForDumbies.ToString();
    }



    if (inputText == "Jarvis Blow Up")
    {
        Instantiate(bombAnimation, bomb.transform.position, Quaternion.identity);

        DestroyObject(bomb);
        explode.Play();
        
        Debug.Log("blew up");
        // Perform actions when the condition is met
    }

    if (inputText.ToLower() == "exit") // Case-insensitive comparison
    {
        Debug.Log("Exiting application...");
        Application.Quit(); // Example action
    }

    if (inputText.ToLower() == "Count to a million") // Case-insensitive comparison
    {
        millionOn = true;

    }

    if (inputText.ToLower() == "Stop") // Case-insensitive comparison
    {
        millionOn = false;

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

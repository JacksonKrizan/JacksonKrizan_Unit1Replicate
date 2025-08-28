using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DestoryTextbox : MonoBehaviour
{
    public GameObject bomb;
    public GameObject explosion;
    //public InputField myInputField;
    public TMP_InputField myInputField;
    public TextMeshProUGUI displayText;
    public TextMeshProUGUI HealthText;
    private string inputText;
    public AudioSource explodeSound;
    public int health = 10;


    void Start()
    {
        explodeSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            HealthText.text = "Health: " + health.ToString();
            DestroyObject(bomb);
            explodeSound.Play();
            Debug.Log("blew up");
        }
        else
        {
            HealthText.text = "Health: " + health.ToString();
        }



    string inputText = myInputField.text;

    if (inputText == "Jarvis Blow Up")
    {
        DestroyObject(bomb);
        explodeSound.Play();
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

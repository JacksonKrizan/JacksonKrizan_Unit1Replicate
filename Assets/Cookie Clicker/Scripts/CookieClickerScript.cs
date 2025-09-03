using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookieClickerScript : MonoBehaviour
{
    public int cookies;
    public int cookiesPerClick;
    public TextMeshProUGUI cookieText;
    public Button cookieButton;
    public AudioSource cookieSound;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        {
            cookiesPerClick = 1;
            cookies = 0;
            cookieSound = GetComponent<AudioSource>();

            // Add listener to cookieButton
            if (cookieButton != null)
            {
                cookieButton.onClick.AddListener(OnCookieButtonClicked);
            }
            UpdateCookieText();
        }
    // Called when cookieButton is clicked
    void OnCookieButtonClicked()
    {
        cookies += cookiesPerClick;
        UpdateCookieText();
        cookieSound.Play();
    }

    // Updates the cookie count display
    void UpdateCookieText()
    {
        if (cookieText != null)
        {
            cookieText.text = "You have: " + cookies;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cookieText != null)
        {
            cookieText.text = "You have: " + cookies;
        }
    }
}

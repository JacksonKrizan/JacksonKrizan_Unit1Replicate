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
    public GameObject tickMarkerPrefab; // Assign a prefab with the tick image in the inspector

    public GameObject gamePanel; // Assign your main game panel in the inspector
    public GameObject shopPanel; // Assign your shop panel in the inspector
    public Button openShopButton; // Assign the button that opens the shop
    public Button returnButton; // Assign the button that returns to the game panel




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
        // Add listener to openShopButton
        if (openShopButton != null)
        {
            openShopButton.onClick.AddListener(OpenShopPanel);
        }
        // Add listener to returnButton
        if (returnButton != null)
        {
            returnButton.onClick.AddListener(ReturnToGamePanel);
        }
        // Ensure panels are in correct state at start
        if (gamePanel != null) gamePanel.SetActive(true);
        if (shopPanel != null) shopPanel.SetActive(false);
        UpdateCookieText();
    }
    // Call this to open the shop and hide the game panel
    public void OpenShopPanel()
    {
        if (gamePanel != null) gamePanel.SetActive(false);
        if (shopPanel != null) shopPanel.SetActive(true);
    }
    // Called when cookieButton is clicked

    void OnCookieButtonClicked()
    {
        cookies += cookiesPerClick;
        UpdateCookieText();
        cookieSound.Play();

        ShowTickMarkerAtMouse();
    }

    void ShowTickMarkerAtMouse()
    {
        if (tickMarkerPrefab != null)
        {
            // Convert mouse position to world position
            Vector3 mousePos = Input.mousePosition;
            Canvas canvas = cookieText != null ? cookieText.canvas : null;
            Vector3 spawnPos = mousePos;
            if (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay)
            {
                RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, mousePos, canvas.worldCamera, out spawnPos);
            }
            // Instantiate the tick marker as a child of the canvas
            GameObject tick = Instantiate(tickMarkerPrefab, spawnPos, Quaternion.identity, canvas != null ? canvas.transform : null);
            // Optionally, set the local position if needed
            if (canvas != null && canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                tick.transform.position = mousePos;
            }
            // Destroy after a short delay
            Destroy(tick, 0.1f);
        }
    }

    // Updates the cookie count display
    void UpdateCookieText()
    {
        if (cookieText != null)
        {
            cookieText.text = "You have: " + cookies;
        }
    }

    // Call this to open the shop and hide the game panel
    /*public void OpenShopPanel()
    {
        if (gamePanel != null) gamePanel.SetActive(false);
        if (shopPanel != null) shopPanel.SetActive(true);
    }*/

    // Call this to return to the game panel and hide the shop panel
    public void ReturnToGamePanel()
    {
        if (shopPanel != null) shopPanel.SetActive(false);
        if (gamePanel != null) gamePanel.SetActive(true);
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

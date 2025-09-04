using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CookieClickerScript : MonoBehaviour
{
    private int autoClickerCount = 0;
    public int cookies;
    public int cookiesPerClick;
    private int grandmaClickerCount = 0;
    public TextMeshProUGUI cookieText;
    public Button cookieButton;
    public AudioSource cookieSound;
    public AudioSource autoClickerSound; // Assign in inspector
    public AudioSource grandmaSound; // Assign in inspector
    public GameObject tickMarkerPrefab; // Assign a prefab with the tick image in the inspector
    public TextMeshProUGUI autoClickerCountText; // Assign the auto clicker count text in the inspector
    public TextMeshProUGUI grandmaClickerCountText; // Assign the grandma clicker count text in the inspector
    public GameObject autoClickerImagePrefab; // Assign the auto clicker image prefab in the inspector
    public GameObject grandmaImagePrefab; // Assign the grandma image prefab in the inspector

    public GameObject gamePanel; // Assign your main game panel in the inspector
    public GameObject shopPanel; // Assign your shop panel in the inspector
    public Button openShopButton; // Assign the button that opens the shop
    public Button returnButton; // Assign the button that returns to the game panel
    public Button shopPurchaseButton; // Assign the shop purchase button in the inspector
    public TextMeshProUGUI insufficientFundsText; // Assign the text for insufficient funds in the inspector
    public Button grandmaPurchaseButton; // Assign the grandma purchase button in the inspector
    public AudioSource insufficientFundsSound; // Assign the insufficient funds sound in the inspector




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
        // Add listener to shopPurchaseButton
        if (shopPurchaseButton != null)
        {
            shopPurchaseButton.onClick.AddListener(BuyFirstShopItem);
        }
        // Add listener to grandmaPurchaseButton
        if (grandmaPurchaseButton != null)
        {
            grandmaPurchaseButton.onClick.AddListener(BuyGrandmaClicker);
        }
        // Hide insufficient funds texts at start
        if (insufficientFundsText != null)
        {
            insufficientFundsText.gameObject.SetActive(false);
        }
        

    // No need to hide a separate grandmaInsufficientFundsText
        // Grandma clicker purchase logic (costs 100 cookies)
        void BuyGrandmaClicker()
    {
        int cost = 100;
        if (cookies >= cost)
        {
            cookies -= cost;
            grandmaClickerCount++;
            UpdateCookieText();
            // Start coroutine only if this is the first grandma
            if (grandmaClickerCount == 1)
            {
                StartCoroutine(AutoAddGrandmaCookies());
            }
        }
        else
        {
            if (insufficientFundsText != null)
            {
                insufficientFundsText.text = "Insufficient funds";
                insufficientFundsText.gameObject.SetActive(true);
                if (insufficientFundsSound != null)
                {
                    insufficientFundsSound.Play();
                }
                StartCoroutine(HideInsufficientFundsText());
            }
        }
        UpdateUpgradeCountTexts(); // Initialize upgrade count texts
    }

    // Coroutine to add 20 cookies per grandma every 1 second
    System.Collections.IEnumerator AutoAddGrandmaCookies()
    {
        while (grandmaClickerCount > 0)
        {
            yield return new WaitForSeconds(4.5f);
            cookies += 20 * grandmaClickerCount;
            UpdateCookieText();
            if (grandmaSound != null)
            {
                grandmaSound.Play();
            }
            ShowGrandmaImage();
        }
        UpdateUpgradeCountTexts(); // Update the count texts after purchase
    }

    // (Removed HideGrandmaInsufficientFundsText, now using HideInsufficientFundsText for both)
        // Ensure panels are in correct state at start
        if (gamePanel != null) gamePanel.SetActive(true);
        if (shopPanel != null) shopPanel.SetActive(false);
        UpdateCookieText();
    }
    // Shop purchase logic for first item (costs 50 cookies)
    void BuyFirstShopItem()
    {
        int cost = 50;
        if (cookies >= cost)
        {
            cookies -= cost;
            autoClickerCount++;
            UpdateCookieText();
            // Start coroutine only if this is the first auto clicker
            if (autoClickerCount == 1)
            {
                StartCoroutine(AutoAddCookies());
            }
        }
        else
        {
            if (insufficientFundsText != null)
            {
                insufficientFundsText.text = "Insufficient funds";
                insufficientFundsText.gameObject.SetActive(true);
                if (insufficientFundsSound != null)
                {
                    insufficientFundsSound.Play();
                }
                StartCoroutine(HideInsufficientFundsText());
            }
        }
    }

    // Coroutine to add 10 cookies per auto clicker every 5 seconds
    System.Collections.IEnumerator AutoAddCookies()
    {
        while (autoClickerCount > 0)
        {
            yield return new WaitForSeconds(5f);
            cookies += 10 * autoClickerCount;
            UpdateCookieText();
            UpdateUpgradeCountTexts();
            if (autoClickerSound != null)
            {
                autoClickerSound.Play();
            }
            ShowAutoClickerImage();
        }
    }
    // Show auto clicker image briefly
    void ShowAutoClickerImage()
    {
        if (autoClickerImagePrefab != null)
        {
            GameObject img = Instantiate(autoClickerImagePrefab, Vector3.zero, Quaternion.identity, gamePanel != null ? gamePanel.transform : null);
            Destroy(img, 0.5f);
        }
    }

    // Show grandma image briefly
    void ShowGrandmaImage()
    {
        if (grandmaImagePrefab != null)
        {
            GameObject img = Instantiate(grandmaImagePrefab, Vector3.zero, Quaternion.identity, gamePanel != null ? gamePanel.transform : null);
            Destroy(img, 0.5f);
        }
    }

    void UpdateUpgradeCountTexts()
    {
        if (autoClickerCountText != null)
        {
            autoClickerCountText.text = "Auto Clickers: " + autoClickerCount;
        }
        if (grandmaClickerCountText != null)
        {
            grandmaClickerCountText.text = "Grandmas: " + grandmaClickerCount;
        }
    }

    // Coroutine to hide the insufficient funds text after 1.5 seconds
    System.Collections.IEnumerator HideInsufficientFundsText()
    {
        yield return new WaitForSeconds(.5f);
        if (insufficientFundsText != null)
        {
            insufficientFundsText.gameObject.SetActive(false);
        }
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
            cookieText.text = cookies.ToString();
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
            cookieText.text = cookies.ToString();
        }
        autoClickerCountText.text = "Auto Clickers: " + autoClickerCount;
        grandmaClickerCountText.text = "Grandmas: " + grandmaClickerCount;
    }
}

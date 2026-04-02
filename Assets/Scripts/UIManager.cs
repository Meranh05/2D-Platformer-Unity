using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject mobileControls;

    public bool fadeToBlack, fadeFromBlack;
    public Image blackScreen;
    public float fadeSpeed = 2f;

    [Header("Main Menu Reference")]
    // THÊM: Kéo GameObject chứa các nút Play/About/Quit vào đây
    public GameObject mainMenuCanvas; 

    [Header("About Panel references")]
    public GameObject aboutPanel;    
    public TMP_Text gameNameText;
    public TMP_Text descriptionText;
    public TMP_Text teamMembersText;

    //player reference
    public PlayerController playerController;

    private void Awake()
    {
        instance = this;

        // Set default About information
        if (gameNameText != null)
            gameNameText.text = "2D Platformer Game";
        if (descriptionText != null)
            descriptionText.text = "Một trò chơi platformer 2D thú vị với các nhân vật dễ thương và thử thách hấp dẫn.";
        if (teamMembersText != null)
            teamMembersText.text = "Thành viên nhóm:\n- Nguyễn Thị Trường Nga\n- Nguyễn Ngọc Hân\n- Ngô Văn Chương";
    }

    // SỬA: Hàm hiện bảng About
    public void ShowAbout()
    {
        if (aboutPanel != null)
        {
            aboutPanel.SetActive(true);
            
            // Ẩn các nút menu chính đi để không bị đè chữ
            if (mainMenuCanvas != null) 
                mainMenuCanvas.SetActive(false);
        }
    }

    // SỬA: Hàm ẩn bảng About để quay lại Menu
    public void HideAbout()
    {
        if (aboutPanel != null)
        {
            aboutPanel.SetActive(false);
            
            // Hiện lại các nút menu chính
            if (mainMenuCanvas != null) 
                mainMenuCanvas.SetActive(true);
        }
    }

    // --- CÁC PHẦN DƯỚI GIỮ NGUYÊN ---
    public void DisableMobileControls()
    {
        mobileControls.SetActive(false);
    }
    public void EnableMobileControls()
    {
        mobileControls.SetActive(true);
    }

    private void Update()
    {
        UpdateFade();
    }

    private void UpdateFade()
    {
        if (fadeToBlack)
        {
            FadeToBlack();
        }
        else if (fadeFromBlack)
        {
            FadeFromBlack();
        }
    }

    private void FadeToBlack()
    {
        FadeScreen(1f);
        if (blackScreen.color.a >= 1f)
        {
            fadeToBlack = false;
        }
    }

    private void FadeFromBlack()
    {
        FadeScreen(0f);
        if (blackScreen.color.a <= 0f)
        {
            if(playerController != null && playerController.controlmode == Controls.mobile)
            {
                EnableMobileControls();
            }
            fadeFromBlack = false;
        }
    }

    private void FadeScreen(float targetAlpha)
    {
        if (blackScreen == null) return;
        Color currentColor = blackScreen.color;
        float newAlpha = Mathf.MoveTowards(currentColor.a, targetAlpha, fadeSpeed * Time.deltaTime);
        blackScreen.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
    }
}
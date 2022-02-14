using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI StartGameTxt;

    public TextMeshProUGUI ScoreTxt;

    public static ChangeColorUI changeColorUI;
    public static ChangeColorBlock changeColorBlock;
    public static TimerScript timerScript;

    private int score = 0;

    [SerializeField]
    private Image ImgFlashRedLight;

    [SerializeField]
    private Button StartGameBtn;

    private void Start()
    {
        ChangeColorBlock.uIManager = this;
        SinusoidBlockMover.uIManager = this;
    }

    public void StartGame()
    {
        timerScript.pauseGame = false;
        changeColorUI.StartGameBtnPressed();
    }

    public void AddScore()
    {
        score += 25;
        DisplayNewScore();
    }

    public void RemoveScore()
    {
        if (score >= 25)
        {
            score -= 25;
            DisplayNewScore();
        }
    }

    private void DisplayNewScore()
    {
        ScoreTxt.text = "Счет: " + score;
    }

    private void FixedUpdate()
    {

        if (ImgFlashRedLight.color.a > 0)
        {
            Color newColor = ImgFlashRedLight.color;
            newColor.a -= 0.01f;
            ImgFlashRedLight.color = newColor;
        }
    }

    public void FlashRedLight()
    {
        ImgFlashRedLight.color = new Color(1, 0, 0, 1);
    }

    public void GamePaused()
    {
        if (StartGameBtn != null)
        {
            score = 0;
            DisplayNewScore();
            StartGameBtn.gameObject.SetActive(true);
            changeColorUI.StopGame();
        }
    }

    private void Update()
    {
        if(timerScript.pauseGame == true)
        {
            GamePaused();
        }
    }
}
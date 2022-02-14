using UnityEngine;

public class ChangeColorUI : UIManager
{
    private bool btnPressed;

    private byte alphaFade = 255;
    private byte alphaAppear = 0;

    private void Start()
    {
        changeColorUI = this;
    }

    public void StartGameBtnPressed()
    {
        btnPressed = true;
    }

    private void FixedUpdate()
    {
        if (btnPressed)
        {
            if (alphaAppear < 255)
            {
                AlphaAppear();
                alphaAppear += 5;
            }
            if (alphaFade > 0)
            {
                AlphaFade();
                alphaFade -= 5;
            }
        }
        if(!btnPressed)
        {
            if (alphaAppear > 0)
            {
                AlphaAppear();
                alphaAppear -= 5;
            }
            if (alphaFade < 255)
            {
                AlphaFade();
                alphaFade += 5;
            }
        }
    }

    private void AlphaFade()
    {
        StartGameTxt.faceColor = new Color32(2,2,2,alphaFade);
    }

    private void AlphaAppear()
    {
        ScoreTxt.gameObject.SetActive(true);
        ScoreTxt.faceColor = new Color32(2, 2, 2, alphaAppear);
    }

    public void StopGame()
    {
        btnPressed = false;
    }
}

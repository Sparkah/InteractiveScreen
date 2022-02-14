using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private float time = 0;
    public bool pauseGame;

    private void Start()
    {
        UIManager.timerScript = this;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            time = 0;
        }
        time += Time.deltaTime;
        if (time >= 15)
        {
            pauseGame = true;
        }
    }
}

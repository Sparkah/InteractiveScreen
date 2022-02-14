using UnityEngine;

public class SinusoidBlockMover : MonoBehaviour
{
    private bool moveRigh;

    private readonly float speedX = 0.02f;
    Vector3 pos;

    private readonly float frequency = 2f;

    private readonly float magnitude = 0.05f;

    public static UIManager uIManager;

    public string color;

    void Start()
    {
        if(transform.position.x<-10)
        {
            moveRigh = true;
        }
        if(transform.position.x>10)
        {
            moveRigh = false;
        }
        pos = new Vector3(speedX, 0, 0);
    }

    private void Update()
    {
        if(transform.position.x>20||transform.position.x<-20)
        {
            Destroy(gameObject);
        }

        if (moveRigh)
        {
            transform.position += pos + magnitude * Mathf.Sin(Time.time * frequency) * transform.up;
        }
        else
        {
            transform.position -= pos + magnitude * Mathf.Sin(Time.time * frequency) * transform.up;
        }
    }
}
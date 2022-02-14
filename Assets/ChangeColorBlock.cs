using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorBlock : MonoBehaviour
{

    private GameObject BottomBlock;
    private int changeColorSpeed = 1000;
    private int initialColorSpeed;
    private bool canBeTaped;

    Color purple;

    private ParticleSystem ps;

    public static UIManager uIManager;

    void Start()
    {
        BottomBlock = gameObject;
        ps = GetComponentInChildren<ParticleSystem>();
        ps.gameObject.SetActive(false);
        initialColorSpeed = changeColorSpeed;
        purple = BottomBlock.GetComponent<Renderer>().material.color;
    }

    // Change color
    private void FixedUpdate()
    {
        if (changeColorSpeed > 0)
        {
            ChangeAlpha(BottomBlock.GetComponent<Renderer>().material);
            changeColorSpeed -= 1;
        }
        else
        {
            canBeTaped = true;
            StartParticleSystem();
        }
    }

    private void ChangeAlpha(Material mat)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r -= 125f / (changeColorSpeed * changeColorSpeed), oldColor.g += 255f / (changeColorSpeed * changeColorSpeed), oldColor.b -= 250f / (changeColorSpeed * changeColorSpeed), 1);
        mat.SetColor("_Color", newColor);
    }

    private void StartParticleSystem()
    {
        ps.gameObject.SetActive(true);
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);
        ResetCubeColor();
    }

    private void ResetCubeColor()
    {
        ps.gameObject.SetActive(false);
        changeColorSpeed = initialColorSpeed;
        BottomBlock.GetComponent<Renderer>().material.color = purple;
    }

    // Detect tap
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.collider!=null)
                {
                    if (hit.collider.gameObject.GetComponent<SinusoidBlockMover>() != null)
                    {
                        if (hit.collider.gameObject.GetComponent<SinusoidBlockMover>().color == "2")
                        {
                            uIManager.AddScore();
                            Destroy(hit.collider.gameObject);
                            return;
                        }
                        if (hit.collider.gameObject.GetComponent<SinusoidBlockMover>().color == "1")
                        {
                            uIManager.AddScore();
                            uIManager.AddScore();
                            Destroy(hit.collider.gameObject);
                            return;
                        }
                        if (hit.collider.gameObject.GetComponent<SinusoidBlockMover>().color == "0")
                        {
                            uIManager.RemoveScore();
                            uIManager.FlashRedLight();
                            Destroy(hit.collider.gameObject);
                            return;
                        }
                    }

                    ChangeColorBlock changeColorBlock = hit.transform.gameObject.GetComponent<ChangeColorBlock>();
                    if (changeColorBlock!=null && changeColorBlock.canBeTaped == true)
                    {
                        changeColorBlock.canBeTaped = false;
                        changeColorBlock.ResetCubeColor();
                        uIManager.AddScore();
                        uIManager.AddScore();
                        uIManager.AddScore();
                        uIManager.AddScore();
                        return;
                    }
                }
            }
        }
    }
}
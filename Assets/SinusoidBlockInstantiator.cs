using System.Collections;
using UnityEngine;

public class SinusoidBlockInstantiator : MonoBehaviour
{
    [SerializeField]
    private Material[] Colors;

    [SerializeField]
    private GameObject Block;

    private readonly int waitingTime = 4;

    void Start()
    {
        StartCoroutine(InstantiateSinusoidBlock());
    }

    IEnumerator InstantiateSinusoidBlock()
    {
        yield return new WaitForSeconds(waitingTime);
        int colorInt = Random.Range(0, Colors.Length);
        GameObject BlockNew = Instantiate(Block, new Vector3(transform.position.x, Random.Range(-3,4), 0), Quaternion.identity);
        BlockNew.GetComponent<Renderer>().material.SetColor("_Color", Colors[colorInt].color);
        BlockNew.GetComponent<SinusoidBlockMover>().color = colorInt.ToString();
        StartCoroutine(InstantiateSinusoidBlock());
    }
}

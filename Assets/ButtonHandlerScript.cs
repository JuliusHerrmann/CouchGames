using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlerScript : MonoBehaviour
{
    public GameObject wait, start;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        wait.SetActive(false);
        start.SetActive(true);
    }
}

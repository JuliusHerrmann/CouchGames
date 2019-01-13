using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMockTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject referenz;
    void Start()
    {
        StartCoroutine(playerCreate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator playerCreate(){
        yield return new WaitForSeconds(3);
        referenz.GetComponent<MainMenu>().playerJoined("Bob",123456, Guid.NewGuid());
        yield return new WaitForSeconds(3);
        Guid testGuid = Guid.NewGuid();
        referenz.GetComponent<MainMenu>().playerJoined("Karl",123456, testGuid);
        yield return new WaitForSeconds(3);
        referenz.GetComponent<MainMenu>().playerWantsToStart(testGuid);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class speicherHandyScript : MonoBehaviour
{
    public int gameId, rundenId;
    public Guid UUid;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);   
    }
}

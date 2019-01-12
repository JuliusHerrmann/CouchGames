using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feldScript : MonoBehaviour
{
    public bool top = false;
    public bool bottom = false;
    public bool left = false;
    public bool right = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBegrenzungen(bool top, bool bottom, bool left, bool right){
        this.top = top;
        this.bottom = bottom;
        this.left = left;
        this.right = right;
    }
}

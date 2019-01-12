using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    GameObject[,] spielfeld = new GameObject[16,16];
    void Start()
    {
        Debug.Log("test");
        for(int i = 0; i < 16; i++){
            for(int a = 0; a < 16; a++){
                Vector3 start = new Vector3((0.5f*i) - 4,(0.5f*a) - 4,0);
                GameObject g = Instantiate(Resources.Load("Feld"), start, Quaternion.identity) as GameObject;
                //feldScript f = g.GetComponent<feldScript>();
                //f.setBegrenzungen(true,true,true,true);
                spielfeld[i,a] = g;
            }
        }

        //Begrenzungen setzten
        //spielfeld[0,1].GetComponent<feldScript>().setBegrenzungen(true,true,true,true);
        for(int i = 0; i < 16; i++){
            spielfeld[i,0].GetComponent<feldScript>().setBegrenzungen(false,true,false,false);
            spielfeld[i,15].GetComponent<feldScript>().setBegrenzungen(true,false,false,false);
            spielfeld[0,i].GetComponent<feldScript>().setBegrenzungen(false,false,true,false);
            spielfeld[15,i].GetComponent<feldScript>().setBegrenzungen(false,false,false,true);
        }

        spielfeld[5,0].GetComponent<feldScript>().right = true;
        spielfeld[5,0].GetComponent<feldScript>().left = true;
        spielfeld[11,0].GetComponent<feldScript>().right = true;
        spielfeld[12,0].GetComponent<feldScript>().left = true;
        spielfeld[1,1].GetComponent<feldScript>().right = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

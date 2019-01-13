using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSolution : MonoBehaviour
{
    public Bewegung.FARBEN color = Bewegung.FARBEN.nichts;
    public Spielstein.MOVEDIRECTION direction;
    public List<Bewegung> potSolutions = new List<Bewegung>();
    List<GameObject> arrows = new List<GameObject>();
    bool entered = false;
    GameObject speicher;
    // Start is called before the first frame update
    void Start()
    {
        speicher = GameObject.FindGameObjectWithTag("Speicher");
    }

    public void startNewRound(int rundenId)
    {
        speicher.GetComponent<speicherHandyScript>().rundenId = rundenId;
        potSolutions.Clear();
        entered = false;
    }

    public void addArrow(Bewegung.FARBEN color, Spielstein.MOVEDIRECTION direction)
    {
        float posx = 50 * potSolutions.Count;
        int zRot = 0;
        switch (direction)
        {
            case Spielstein.MOVEDIRECTION.right:
                zRot = 0;
                break;
            case Spielstein.MOVEDIRECTION.top:
                zRot = 90;
                break;
            case Spielstein.MOVEDIRECTION.down:
                zRot = -90;
                break;
            case Spielstein.MOVEDIRECTION.left:
                zRot = -180;
                break;
        }
        switch (color)
        {
            case Bewegung.FARBEN.blau:
                arrows.Add(Instantiate(Resources.Load("ArrowBlue"), new Vector3(posx, 476, 0), Quaternion.Euler(0,0,(float) zRot), GameObject.Find("Panel").transform) as GameObject);
                break;
            case Bewegung.FARBEN.gruen:
                arrows.Add(Instantiate(Resources.Load("ArrowGreen"), new Vector3(posx, 476, 0), Quaternion.Euler(0, 0, (float)zRot), GameObject.Find("Panel").transform) as GameObject);
                break;
            case Bewegung.FARBEN.rot:
                arrows.Add(Instantiate(Resources.Load("ArrowRed"), new Vector3(posx, 476, 0), Quaternion.Euler(0, 0, (float)zRot), GameObject.Find("Panel").transform) as GameObject);
                break;
            case Bewegung.FARBEN.gelb:
                arrows.Add(Instantiate(Resources.Load("ArrowYellow"), new Vector3( posx, 476, 0), Quaternion.Euler(0, 0, (float)zRot), GameObject.Find("Panel").transform) as GameObject);
                break;
        }
    }

    // Update is called once per frame
    public void delete()
    {
        potSolutions.Clear();
        foreach(GameObject g in arrows)
        {
            Destroy(g);
        }
        arrows.Clear();
    }

    public void enter()
    {
        entered = true;
        Solution s = new Solution(potSolutions, new Player(speicher.GetComponent<speicherHandyScript>().name, false, speicher.GetComponent<speicherHandyScript>().UUid));
        //Send solution to server
    }

    public void colorRot()
    {
        if(entered == true) { return; }
        color = Bewegung.FARBEN.rot;
    }
    public void colorGelb()
    {
        if (entered == true) { return; }
        color = Bewegung.FARBEN.gelb;
    }
    public void colorBlau()
    {
        if (entered == true) { return; }
        color = Bewegung.FARBEN.blau;
    }
    public void colorGruen()
    {
        if (entered == true) { return; }
        color = Bewegung.FARBEN.gruen;
    }

    public void directionUp()
    {
        if (entered == true) { return; }
        if (color != Bewegung.FARBEN.nichts)
        {
            Bewegung b = new Bewegung(Spielstein.MOVEDIRECTION.top, color);
            potSolutions.Add(b);
            addArrow(color, Spielstein.MOVEDIRECTION.top);
            color = Bewegung.FARBEN.nichts;
        }
    }
    public void directionDown()
    {
        if (entered == true) { return; }
        if (color != Bewegung.FARBEN.nichts)
        {
            Bewegung b = new Bewegung(Spielstein.MOVEDIRECTION.down, color);
            potSolutions.Add(b);
            addArrow(color, Spielstein.MOVEDIRECTION.down);
            color = Bewegung.FARBEN.nichts;
        }
    }
    public void directionLeft()
    {
        if (entered == true) { return; }
        if (color != Bewegung.FARBEN.nichts)
        {
            Bewegung b = new Bewegung(Spielstein.MOVEDIRECTION.left, color);
            potSolutions.Add(b);
            addArrow(color, Spielstein.MOVEDIRECTION.left);
            color = Bewegung.FARBEN.nichts;
        }
    }
    public void directionRight()
    {
        if (entered == true) { return; }
        if (color != Bewegung.FARBEN.nichts)
        {
            Bewegung b = new Bewegung(Spielstein.MOVEDIRECTION.right, color);
            potSolutions.Add(b);
            addArrow(color, Spielstein.MOVEDIRECTION.right);
            color = Bewegung.FARBEN.nichts;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class figurenController : MonoBehaviour
{
    public GameObject fRot, fGruen, fBlau, fGelb;
    public bool solutionInProgress;
    List<Bewegung> alleBewegungen = new List<Bewegung>();
    List<Vector3> startPos = new List<Vector3>();
    bool start = false;
    bool lastSolution = false;
    GameObject speicher;
    // Start is called before the first frame update
    public void Start()
    {
        speicher = GameObject.FindGameObjectWithTag("Speicher");
        startPos.Add(fRot.transform.position);
        startPos.Add(fGruen.transform.position);
        startPos.Add(fBlau.transform.position);
        startPos.Add(fGelb.transform.position);
    }

    public void setSolution(Solution solution){
        alleBewegungen = solution.moves;
    }

    public void startMoves(bool isLastSolution){
        start = true;
        solutionInProgress = true;
        this.lastSolution = isLastSolution;
    }
    int step = 0;
    void Update(){
        if(start){
            if(step < alleBewegungen.Count){
                if(!fRot.GetComponent<Spielstein>().moving && !fGruen.GetComponent<Spielstein>().moving && !fBlau.GetComponent<Spielstein>().moving && !fGelb.GetComponent<Spielstein>().moving)
                {
                    bewegungAusfuehren(alleBewegungen[step]);
                    step ++;
                }
            }
            else
            {
                solutionInProgress = false;
                step = 0;
                start = false;
                if (!lastSolution)
                {
                    resetFiguren();
                }
                else
                {
                    startPos[0] = fRot.transform.position;
                    startPos[1] = fGruen.transform.position;
                    startPos[2] = fGelb.transform.position;
                    startPos[3] = fBlau.transform.position;
                    speicher.GetComponent<PlayerList>().startPos = startPos;
                }
            }
        }
    }

    public void bewegungAusfuehren(Bewegung b)
    {
        GameObject figur = b.getFigur();
        Spielstein s = figur.GetComponent<Spielstein>();
        s.move(b.getDirection());
    }

    public void resetFiguren()
    {
        fRot.transform.position = startPos[0];
        fGruen.transform.position = startPos[1];
        fBlau.transform.position = startPos[2];
        fGelb.transform.position = startPos[3];
    }
}

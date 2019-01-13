using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private const int MAX_SECONDS_TIMER = 60;

    public List<Solution> solutionsForRound = new List<Solution>();
    public GameObject speicher;
    public GameObject timer, figurenController;
    public int seconds = MAX_SECONDS_TIMER;

    public void Start()
    {
        //speicher = GameObject.Find("PlayerListObject");
    }

    /// <summary>
    /// Wird aufgerufen, wenn ein player eine solution abgeschickt hat.
    /// </summary>
    /// <param name="solution"></param>
    public void solutionSubmitted(Solution solution)
    {
        if(solutionsForRound.Count == 0){
            startTimer();
        }
        solutionsForRound.Add(solution);
        if(solutionsForRound.Count == speicher.GetComponent<PlayerList>().allePlayer.Count){
            seconds = 1;
        }
    }
    

    public void startNewRound()
    {
        //Send Id um zu starten
        //playerList.GetComponent<PlayerList>().gameId;
        seconds = MAX_SECONDS_TIMER;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void startTimer()
    {
        StartCoroutine(start());
    }

    private void startSolutionSolving()
    {
        // alle solutions durchlaufen
        runAllSolutions();
        
        // Solutions bewerten und sortieren
        evaluateSolutions();

        // punkte der runde zu den einzelnen Spielern hinzufügen
        //TODO

        // nächste Runde starten
        startNewRound();
    }

    /// <summary>
    /// Lässt im figurenController nacheinander alle solutions durchlaufen
    /// </summary>
    private void runAllSolutions()
    {
        figurenController figController = figurenController.GetComponent<figurenController>();
        int solutionNumber = 1;
        foreach (Solution solution in solutionsForRound)
        {
            bool isLastSolutionOfRound = solutionNumber == solutionsForRound.Count;
            figController.setSolution(solution);
            figController.startMoves(isLastSolutionOfRound);

            while (figController.solutionInProgress)
            {
                // warten bis die solution fertig durchlaufen wurde
            }
        }
    }

    IEnumerator start()
    {
        while (seconds > 0)
        {
            timer.GetComponent<TextMeshProUGUI>().text = seconds.ToString();
            seconds--;
            yield return new WaitForSeconds(1);
        }

        // Lösungsvorgang starten wenn der Timer abgelaufen ist.
        startSolutionSolving();
    }

    /// <summary>
    /// bewertet alle solutions und sortiert sie danach, ob sie korrekt waren und welche solution
    /// </summary>
    private void evaluateSolutions()
    {
        //TODO
    }
}

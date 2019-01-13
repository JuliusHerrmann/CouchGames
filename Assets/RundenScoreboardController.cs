using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

/// <summary>
/// Diese Klasse sorgt dafür, dass die Spieler mit ihren Infos zu der aktuellen Runde korrekt angzeigt werden.
/// </summary>
public class RundenScoreboardController : MonoBehaviour
{
    public List<Solution> roundSolutions;
    public Solution currentlyRunningSolution;
}

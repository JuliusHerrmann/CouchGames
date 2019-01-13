using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// Diese Klasse sorgt dafür, dass die Spieler mit ihren Infos zu der aktuellen Runde korrekt angzeigt werden.
/// </summary>
public class RundenScoreboardController : MonoBehaviour
{
    public List<Solution> roundSolutions;
    public Solution currentlyRunningSolution;
    //public List<TextMeshProUGUI> PlayerScoreLabels = new List<TextMeshProUGUI>();
    public TextMeshProUGUI Player1NameText;
    public TextMeshProUGUI Player2NameText;
    public TextMeshProUGUI Player3NameText;
    public TextMeshProUGUI Player4NameText;
    public TextMeshProUGUI Player1MovesText;
    public TextMeshProUGUI Player2MovesText;
    public TextMeshProUGUI Player3MovesText;
    public TextMeshProUGUI Player4MovesText;
    public TextMeshProUGUI Player1TimeText;
    public TextMeshProUGUI Player2TimeText;
    public TextMeshProUGUI Player3TimeText;
    public TextMeshProUGUI Player4TimeText;

    public void initializeScoreLabels()
    {
        // try to set text of player1
        if (roundSolutions.Count > 0)
        {
            Solution solution1 = roundSolutions[0];
            Player1NameText.text = solution1.player.name;
            Player1MovesText.text = solution1.moves.Count.ToString();
            Player1TimeText.text = solution1.secondsLeftWhenSubmitted.ToString();
        }
        // try to set text of player2
        if (roundSolutions.Count > 1)
        {
            Solution solution2 = roundSolutions[1];
            Player2NameText.text = solution2.player.name;
            Player2MovesText.text = solution2.moves.Count.ToString();
            Player2TimeText.text = solution2.secondsLeftWhenSubmitted.ToString();
        }
        // try to set text of player3
        if (roundSolutions.Count > 2)
        {
            Solution solution3 = roundSolutions[2];
            Player3NameText.text = solution3.player.name;
            Player3MovesText.text = solution3.moves.Count.ToString();
            Player3TimeText.text = solution3.secondsLeftWhenSubmitted.ToString();
        }
        // try to set text of player4
        if (roundSolutions.Count > 3)
        {
            Solution solution4 = roundSolutions[3];
            Player4NameText.text = solution4.player.name;
            Player4MovesText.text = solution4.moves.Count.ToString();
            Player4TimeText.text = solution4.secondsLeftWhenSubmitted.ToString();
        }
    }

    private string getTextToDisplay(Solution solution)
    {
        string displayText = string.Format("{0} m:{1} t:{2}", solution.player.name, solution.moves.Count, solution.secondsLeftWhenSubmitted);
        return displayText;
    }
}

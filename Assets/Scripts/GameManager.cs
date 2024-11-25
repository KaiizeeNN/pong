using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public TMP_Text textMeshProComputer;
    public TMP_Text textMeshProPlayer;

    private int playerScore;
    private int computerScore;

    public void PlayerScores()
    {

        playerScore++;
        textMeshProPlayer.text = playerScore.ToString();
        this.ball.ResetPosition();

    }


    public void ComputerScores()
    {
        computerScore++;
        textMeshProComputer.text = computerScore.ToString();
        this.ball.ResetPosition();
    }


}

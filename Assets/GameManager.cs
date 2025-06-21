using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    private int leftScore = 0;
    private int rightScore = 0;

    public void ScoreLeft()
    {
        leftScore++;
        leftScoreText.text = leftScore.ToString();
    }

    public void ScoreRight()
    {
        rightScore++;
        rightScoreText.text = rightScore.ToString();
    }
}

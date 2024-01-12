using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText = null;  // Reference to the UI Text component for displaying the score
    private int currentScore = 0;

    void Start()
    {
        // Initialize the score
        UpdateScoreText();
    }

    // Call this method to increase the player's score
    public void IncreaseScore(int points)
    {
        currentScore += points;
        UpdateScoreText();
    }

    // Call this method to get the current score
    public int GetCurrentScore()
    {
        return currentScore;
    }

    // Update the UI Text component with the current score
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }

    // Call this method to add a specific score to the current score
    public void AddScore(int additionalScore)
    {
        IncreaseScore(additionalScore);
    }
}

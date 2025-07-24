using UnityEngine;

public class PlayerScores : MonoBehaviour
{
    private static int _scores = 0;

    /// <summary>
    /// Update player scores
    /// </summary>
    public static void UpdateScore(int score)
    {
        _scores += score;
        UIManager.Instance.UpdateUIScore(_scores);
    }
}

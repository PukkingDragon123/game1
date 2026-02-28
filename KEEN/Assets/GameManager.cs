using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentScore = 0;
    public TextMeshProUGUI scoretxt;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void UpdateScore(int score)
    {
        currentScore += score;
        scoretxt.text = "KILLS:"+currentScore.ToString();
    }
    private void Start()
    {
        scoretxt.text = "KILLS:" + currentScore.ToString();
    }
}

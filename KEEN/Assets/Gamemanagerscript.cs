using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Gamemanagerscript : MonoBehaviour
{
    public List<GameObject> targetList;
    public float spawnrate = 0.5f;
    public TextMeshProUGUI scoretxt;
    public int score = 0;
    public GameObject gameover;
    public bool Over;
    // Start is called before the first frame update
    void Start()
    {
        scoretxt.text = "Score: " + score.ToString();
        StartCoroutine(SpawnTarget());
        gameover.SetActive(false);
        Over = false;
    }


    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnTarget()
    {
        while (Over == false)
        {
            yield return new WaitForSeconds(spawnrate);
            int index = Random.Range(0, targetList.Count);
            Instantiate(targetList[index]);





        }

    }
    public void UpdatePoint(int newscore)
    {
        score += newscore;
        scoretxt.text = "SCORE: " + score.ToString();
        if (score < 0)
        {
            Gameover();
            Over = (true);
        }
    }
    private void Gameover()
    {
        gameover.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}

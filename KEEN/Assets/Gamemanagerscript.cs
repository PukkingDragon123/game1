using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Gamemanagerscript : MonoBehaviour
{
    public List<GameObject> targetList;
    public float spawnrate = 0.5f;
    public TextMeshProUGUI scoretxt;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoretxt.text = "Score: " + score.ToString();
        StartCoroutine(SpawnTarget());
    }


    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnrate);
            int index = Random.Range(0, targetList.Count);
            Instantiate(targetList[index]);





        }

    }
    public void UpdatePoint(int newscore)
    {
        score += newscore;
        scoretxt.text = "SCORE:" + score.ToString();
    }

    

}

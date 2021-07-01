using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreMode : MonoBehaviour
{
    //axis z 66
    public int score;
    int highScore;

    public Text txtScore;
    public Text[] txtHighscore;

    public float spawnPosition = 670;

    public GameObject scorePanel;
    public GameObject hintHighscore;

    public GameObject[] level;

    public Text[] txtNameTable;
    public Text[] txtScoreTable;

    HighscoreMode hsm;

    private void Awake()
    {
        hsm = this.GetComponent<HighscoreMode>();
    }

    private void Start()
    {

        txtScore.text = highScore + "";
        for (int i = 0; i < txtHighscore.Length; i++)
        {
            txtHighscore[i].text = highScore + "";
        }
        highScore = PlayerPrefs.GetInt("highScore");

        for (int i = 0; i < txtNameTable.Length; i++)
        {
            txtNameTable[Random.Range(0, 5)].text = "- John";
            txtNameTable[Random.Range(0, 5)].text = "- Mark";
            txtNameTable[Random.Range(0, 5)].text = "- Emma";
            txtNameTable[Random.Range(0, 5)].text = "- Olivia";
            txtNameTable[Random.Range(0, 5)].text = "- Oliver";
            txtNameTable[Random.Range(0, 5)].text = "- William";
            txtNameTable[Random.Range(0, 5)].text = "- Mia";
            txtNameTable[Random.Range(0, 5)].text = "- Emily";
            txtNameTable[Random.Range(0, 5)].text = "- Henry";
            txtNameTable[Random.Range(0, 5)].text = "- Jacob";
            txtNameTable[Random.Range(0, 5)].text = "- Sofia";
            txtNameTable[Random.Range(0, 5)].text = "- Mila";
            txtNameTable[Random.Range(0, 5)].text = "- Levi";
            txtNameTable[Random.Range(0, 5)].text = "- Jack";
            txtNameTable[Random.Range(0, 5)].text = "- Victoria";
            txtNameTable[Random.Range(0, 5)].text = "- Nora";
            txtNameTable[Random.Range(0, 5)].text = "- David";
            txtNameTable[Random.Range(0, 5)].text = "- Isaac";
            txtNameTable[Random.Range(0, 5)].text = "- Vadim";
        }

        for (int i = 0; i < txtScoreTable.Length; i++)
        {
            txtScoreTable[4].text = hsm.highScore + Random.Range(25, 65) + "";
            txtScoreTable[3].text = hsm.highScore + Random.Range(70, 110) + "";
            txtScoreTable[2].text = hsm.highScore + Random.Range(120, 160) + "";
            txtScoreTable[1].text = hsm.highScore + Random.Range(170, 210) + "";
            txtScoreTable[0].text = hsm.highScore + Random.Range(220, 260) + "";
        }
    }

    private void Update()
    {
        if (score > highScore)
        {
            highScore = score;
        }
        txtScore.text = score + "";

        for (int i = 0; i < txtHighscore.Length; i++)
        {
            txtHighscore[i].text = highScore + "";
        }

        if (highScore > 500)
        {
            hintHighscore.SetActive(false);
        }
    }

    public void SpawnLevel()
    {
        spawnPosition += 66;
        GameObject spanwedLevel = Instantiate(level[Random.Range(0, level.Length)]);
        spanwedLevel.SetActive(true);
        spanwedLevel.transform.position = new Vector3(0, 0, spawnPosition);
    }

    public void ScoreTrigger()
    {
        score += Random.Range(50, 100);
        PlayerPrefs.SetInt("highScore", highScore);
    }
}

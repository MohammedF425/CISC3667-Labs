using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] float score = 0;
    const int DEFAULT_POINTS = 1;

    [SerializeField] Text scoreText;

    string playerName;
    // Start is called before the first frame update
    void Start()
    {
        score=PersistentData.Instance.GetScore();
        playerName=PersistentData.Instance.GetName();
        scoreText.text = "Score: "+ score.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        //delete
        score=PersistentData.Instance.GetScore();
        scoreText.text = "Score: "+ score.ToString("0.00");




    }
    public void AddPoints(float addend){
        PersistentData.Instance.AddToScore(addend);
        score=PersistentData.Instance.GetScore();
        Debug.Log("score "+ score);
        scoreText.text = "Score: "+ score.ToString("0.00");;

    }
}

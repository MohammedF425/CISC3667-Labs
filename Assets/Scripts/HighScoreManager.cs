using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] float playerScore;
    [SerializeField] Text[] nameTexts;
    [SerializeField] Text[] scoreTexts;
    [SerializeField] Text currentName;
    [SerializeField] Text currentScore;

    const string player = "Player";
    const string score = "Score";

    // Start is called before the first frame update
    void Start()
    {
        playerName = PersistentData.Instance.GetName();
        playerScore = PersistentData.Instance.GetScore();
        currentName.text = playerName;
        currentScore.text = playerScore.ToString("0.00");
        SaveHighScores();

        for (int i = 0; i < 5; i++)
        {
            int j= i+1;
            Debug.Log(j + " " + PlayerPrefs.GetString(player + j));
            Debug.Log(j + " " + PlayerPrefs.GetFloat(score + j));
        }

        ShowHighScores();
    }

    public void ShowHighScores(){
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i + " ");
            nameTexts[i].text = PlayerPrefs.GetString(player + (i + 1));
            scoreTexts[i].text = PlayerPrefs.GetFloat(score + (i + 1)).ToString("0.00");
        }
    }

    public void SaveHighScores(){
        for (int i = 1; i <= 5; i++){
            Debug.Log("Level qwe");
            string currentNameKey = player + i;
            string currentScoreKey = score + i;

            if (PlayerPrefs.HasKey(currentScoreKey)){
                Debug.Log("Level qwe");

                float currentScore = PlayerPrefs.GetFloat(currentScoreKey);
                if (playerScore > currentScore){
                    Debug.Log("Level qwe");

                    float tempScore = currentScore;
                    string tempName = PlayerPrefs.GetString(currentNameKey);
                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetFloat(currentScoreKey, playerScore);
                    playerName = tempName;
                    playerScore = tempScore;
                }
            }
            else{
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetFloat(currentScoreKey, playerScore);
            }
            int j= i+1;
            Debug.Log(j + " " + PlayerPrefs.GetString(player + j));
            Debug.Log(j + " " + PlayerPrefs.GetFloat(score + j));
        }
    }
}

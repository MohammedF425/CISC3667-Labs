using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{

    [SerializeField] InputField playerNameInput;

    // Start is called before the first frame update


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goToScene1(){
        string name = playerNameInput.text;
        PersistentData.Instance.SetName(name);
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene("Scene1");
    }
    public void GoToDirections(){
        SceneManager.LoadScene("Directions");
    }
    public void GoToMainMenu(){
        SceneManager.LoadScene("menu");

    }
    public void GoToSettings(){
        SceneManager.LoadScene("settings");
        SettingsMenu.Instance.gameObject.SetActive(true);
    }
    public void Pause(){
        Time.timeScale = 0.0f;
    }
    public void Resume(){
        Time.timeScale = 1.0f;
    }
    public void GoToHighscores(){
        SceneManager.LoadScene("HighScores");
    }
}

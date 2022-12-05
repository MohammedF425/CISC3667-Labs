using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public bool hard =false;
    public static SettingsMenu Instance;
    void Awake(){
        if(Instance !=null){
            Destroy(gameObject);
        }
        else{
            gameObject.SetActive(true);
            DontDestroyOnLoad(this);
            Instance=this;
        }
    }
    public void MuteToggle(bool muted){
        if(muted){
            AudioListener.pause = true;
            AudioListener.volume=0;
        }
        else{
            AudioListener.pause = false;
            AudioListener.volume=1;
        }
    }
    public void slideVolume(float vol){
        AudioListener.volume=vol;
    }
    public void GoToMenu(){
        SceneManager.LoadScene("menu");
        gameObject.SetActive(false);
    }
    public void easy(){
        hard=false;
    }
    public void notEasy(){
        hard=true;
    }
    public bool isHard(){
        return hard;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] float score;

    public static PersistentData Instance;

    public void Awake(){
        if(Instance !=null){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(this);
            Instance=this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        score = 0;
        SettingsMenu.Instance.easy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetName(string name){
        playerName=name;
    }
    public string GetName(){
        return playerName;
    }
    public void SetScore(float num){
        score = num;
    }
    public float GetScore(){
        return score;
    }
    public void AddToScore(float num){
        score+=num;
    }
}

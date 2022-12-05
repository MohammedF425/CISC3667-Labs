using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    public float velocity;


    public ScoreManager scoreManager;

    public AudioSource popSource;


    // Start is called before the first frame update
    void Start()
    {
        if(rigid==null)
			rigid = GetComponent<Rigidbody2D>();

        popSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(velocity,0);
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Ballon"){
            PersistentData.Instance.AddToScore(10-other.transform.localScale.x*5);
            popSource.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Balloon destoryed");

        }
        if(other.gameObject.tag=="Obstacle"){
            PersistentData.Instance.AddToScore(-2);
            popSource.Play();
            if(SettingsMenu.Instance.isHard()){
                 Destroy(gameObject);
            }
            Debug.Log("Bird!!");

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class balloon : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] bool isGrounded = false;

    public float popSize;
    public float amp;
    public float freq;
    public float Horizontal;
    Vector3 pos;

    public AudioSource popSource;



    // Start is called before the first frame update
    void Start()
    {
        if(rigid == null)
            rigid = gameObject.GetComponent<Rigidbody2D>();
        
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x>popSize){
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PersistentData.Instance.AddToScore(-10);

        }

    }

    void FixedUpdate(){

        pos = transform.position;

        transform.position = new Vector3(pos.x - Horizontal, Mathf.Sin(Time.time * freq) * amp + pos.y, 0);

      
        transform.localScale = transform.localScale + new Vector3(.05f,.05f,.05f) * Time.deltaTime;
    }

    void OnCollisionEnter2D (Collision2D collision){
		if (collision.gameObject.tag == "Ground")
			isGrounded = true;
		if (collision.gameObject.tag == "Bullet")
            popSource.Play();



    }

}

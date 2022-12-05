// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Linq;
// using UnityEngine.UI;

// public class ScoreUi : MonoBehaviour
// {
//     public RowUi rowUi;
//     public HighScoreManager scoreManager;
//     private bool addedscore = false;
//     // public TextMeshProUGUI passRFail;
//     // Start is called before the first frame update
//     void Start()
//     {
//         //  scoreManager.AddScore(new Score(1000));
//         // scoreManager.AddScore(new Score(9));
//         // scoreManager.AddScore(new Score(2));
//         // scoreManager.AddScore(new Score(32));
//         // scoreManager.AddScore(new Score(PersistentData.Instance.score))
//         // var scores = scoreManager.GetHighScores().ToArray();
//         var scoreboardLength = 5;
//         if(scores.Length<5)
//             scoreboardLength = scores.Length;
//         for(int i=0; i < scoreboardLength;i++)
//         {
//             var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
//             row.name.text = (i+1).ToString();
//             // row.name.text = scores[i].name
//             row.score.text = scores[i].score.ToString("0.00");        
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {

        
//     }
// }

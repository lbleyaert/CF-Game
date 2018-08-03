using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;

    private Text scoreText;


	// Use this for initialization
	void Awake () {
        scoreText = GetComponent<Text>();
        score = 0;

	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
	}
}

/*Unity tutorial for scoring points:
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/counting-points-and-displaying-score?playlist=17147
 * https://unity3d.com/learn/tutorials/projects/survival-shooter-tutorial/scoring-points?playlist=17144
 */

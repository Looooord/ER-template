using UnityEngine.UI; 
using UnityEngine;

public class ScoreText : MonoBehaviour {

    Text scoreText;
    static ScoreText st;

    private void Awake()
    {
        st = this;
        scoreText = GetComponent<Text>(); 
    }

    // Update is called once per frame

    public static void SetScoreText(int value)
    {
        st.scoreText.text = string.Format("SCORE: " + value); 
    }
}

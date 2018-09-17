using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject teamPrefab;
    static GameObject team;
    static GameMaster gm;

    static SoundManager sm;
    static int score = 0;
    public static int highscore;


    private void Awake()
    {
        if (PlayerPrefs.HasKey("highscore")) highscore = PlayerPrefs.GetInt("highscore");
        gm = this;
        sm = SoundManager.instance;
        team = GameObject.Find("Team");
    }

    private void OnEnable()
    {
        score = 0;
    }

    public static void GameOver()
    {
        sm.PlayFailAudio();
        SaveScore();
        gm.gameOverPanel.SetActive(true);

    }

    public static void IncreaseScore(int value)
    {
        score += value;
        Debug.Log(score);
        ScoreText.SetScoreText(score);
    }

    public static void SaveScore()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
}

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{

    [SerializeField] Button tryAgainButton;
    [SerializeField] Button menuButton;
    [SerializeField] Button quitButton;
    [SerializeField] Text highscore;

    SoundManager sm;

    private void Awake()
    {
        sm = SoundManager.instance;
        tryAgainButton.onClick.AddListener(delegate { TryAgain(); });
        menuButton.onClick.AddListener(delegate { MenuButton(); });
        quitButton.onClick.AddListener(delegate { QuitButtonTask(); });
        GameMaster.SaveScore();
        highscore.text = string.Format("HIGHSCORE: " + GameMaster.highscore);
    }

    void TryAgain()
    {
        sm.PlayInGameAudio();
        SceneManager.LoadScene("gameSceneTest");
    }

    private void MenuButton()
    {
        SceneManager.LoadScene("Main Menu");
        sm.sceneSelector = SceneSelector.mainMenu;
        sm.SwitchScene();
        sm.PlayMenuAudio();
    }

    private void QuitButtonTask()
    {
        Debug.Log("<color=red>QUIT!</color>");
        Application.Quit();
    }
}

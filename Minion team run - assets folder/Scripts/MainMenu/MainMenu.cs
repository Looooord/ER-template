using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button creditsButton;
	[SerializeField] GameObject mainMenu;
	[SerializeField] GameObject creditsMenu;
	[SerializeField] Transform creditsText;
	[SerializeField] float creditSpeed;
	public bool creditsIsEnabled;

    SoundManager sm;

    private void Awake()
    {
		mainMenu.SetActive(true);
		creditsMenu.SetActive(false);
		creditsIsEnabled = false;
        sm = SoundManager.instance;
        startButton.onClick.AddListener(delegate { StartButtonTask(); });
        quitButton.onClick.AddListener(delegate { QuitButtonTask(); });
        creditsButton.onClick.AddListener(delegate { CreditsButtonTask(); }); 
    }

    private void StartButtonTask()
    {
        SceneManager.LoadScene("gameSceneTest");
        sm.sceneSelector = SceneSelector.gameScene;
        sm.SwitchScene();
    }

    private void QuitButtonTask()
    {
        Debug.Log("<color=red>QUIT!</color>");
        Application.Quit();
    }

    private void CreditsButtonTask()
    {
		mainMenu.SetActive(false);
		creditsMenu.SetActive(true);
		creditsIsEnabled = true;
    }

    public void ButtonHover(GameObject btn)
    {
        btn.transform.localScale = new Vector2(btn.transform.localScale.x + 0.5f, btn.transform.localScale.y + 0.5f);
    }

    public void ButtonExit(GameObject btn)
    {
        btn.transform.localScale = new Vector2(btn.transform.localScale.x - 0.5f, btn.transform.localScale.y - 0.5f);
    }

	private void Update()
	{
        if (creditsIsEnabled && Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.SetActive(true);
            creditsMenu.SetActive(false);
            creditsIsEnabled = false;
        }
	}

}

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{

    [SerializeField] Button menuButton;
    [SerializeField] Button quitButton;

    private void Awake()
    {
        menuButton.onClick.AddListener(delegate { MenuButton(); });
        quitButton.onClick.AddListener(delegate { QuitButtonTask(); });
        GameMaster.SaveScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            MenuController.menuIsClosed = true;
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    private void MenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void QuitButtonTask()
    {
        Application.Quit();
    }




}

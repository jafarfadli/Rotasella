using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausebuttons : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] string currentScene;

    public void resume(){
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void home(){
        SceneManager.LoadSceneAsync("Home");
        Time.timeScale = 1;
    }

    public void restart(){
        SceneManager.LoadSceneAsync(currentScene);
        Time.timeScale = 1;
    }
}

using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;

    void Awake(){
        pauseUI.SetActive(false);
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!pauseUI.activeInHierarchy){
                pauseUI.SetActive(true);
                Time.timeScale = 0;
            } else{
                pauseUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}

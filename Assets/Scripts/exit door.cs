using UnityEngine;
using UnityEngine.SceneManagement;

public class exitdoor : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject playerExit;
    [SerializeField] string nextScene;

    private Animator anim;

    private float wintime = 0;

    void Awake(){
        anim = GetComponent<Animator>();
        playerExit.SetActive(false);
    }
    void Update()
    {
        if (playerMovement.win){
            wintime += Time.deltaTime;

            anim.SetBool("win",true);
            playerExit.SetActive(true);
        }
        if (wintime > 1){
            SceneManager.LoadScene(nextScene);
        }
    }
}

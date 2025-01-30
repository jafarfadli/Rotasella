using UnityEngine;
using UnityEngine.SceneManagement;
public class story : MonoBehaviour
{
    [SerializeField] string nextScene;

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene(nextScene);
        }
    }
}

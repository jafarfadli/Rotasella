using UnityEngine;
using UnityEngine.SceneManagement;

public class Homebuttons : MonoBehaviour
{
    private bool startplay;
    private float playtime = 0;

    private AudioSource audioSource;

    void Awake(){
        audioSource = GetComponent<AudioSource>();
        startplay = false;
    }

    void Update(){
        if(startplay){
            playtime += Time.deltaTime;
        }
        if (playtime > 0.5f){
            SceneManager.LoadScene("Story 1");
        }
    }
    public void play(){
        audioSource.Play();
        startplay = true;
    }
}

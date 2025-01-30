using UnityEngine;

public class Plateactions : MonoBehaviour
{
    [SerializeField] private GameObject lift;
    [SerializeField] private LayerMask objectLayer;
    private BoxCollider2D boxCollider2D;
    private AudioSource audioSource;

    void Awake(){
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.up, 0.1f, objectLayer);
        if (raycastHit.collider != null){
            audioSource.Play();
            lift.GetComponent<Platformmovement>().moveUp();
            
        } else {
            lift.GetComponent<Platformmovement>().moveDown();
        }
    }
}

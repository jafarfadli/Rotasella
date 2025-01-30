using UnityEngine;

public class Chestobtain : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    private BoxCollider2D boxCollider2D;
    private Animator anim;

    public bool chestObtained { get; private set; }

    void Awake()
    { 
        boxCollider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        chestObtained = false;
    }

    void Update()
    {
        if (detectPlayer()){
            chestObtained = true;
            anim.SetBool("open", true);
        }
    }

    private bool detectPlayer(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, playerLayer);
        return raycastHit.collider != null;
    }
}

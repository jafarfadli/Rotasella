using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    [SerializeField] private float speed;
    [SerializeField] private Transform leftButton;
    [SerializeField] private Transform rightButton;
    [SerializeField] private Transform leftStartingPoint;
    [SerializeField] private Transform rightStartingPoint;   
    [SerializeField] private LayerMask exitLayer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider2D;
    private Animator anim;
    [SerializeField] private Keycardobtain keycardobtain;

    public bool win {get; private set;}

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        win = false;
    }

    private void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");
        if (leftButton.position != leftStartingPoint.position){
            if (horizontalInput < 0){
                horizontalInput = 0;
            } 
        }
        if (rightButton.position != rightStartingPoint.position){
            if (horizontalInput > 0){
                horizontalInput = 0;
            } 
        }
        
        body.linearVelocity = new Vector2(horizontalInput * speed,body.linearVelocity.y);

        if (horizontalInput > 0.01f){
            transform.localScale = new Vector3(1,1,1);
        } else if (horizontalInput < -0.01f){
            transform.localScale = new Vector3(-1,1,1);
        }

        anim.SetBool("move", horizontalInput != 0);
        transform.rotation = Quaternion.Euler(0,0,0);

        if (inExit() && keycardobtain.cardObtained){
            win = true;
            gameObject.SetActive(false);
        }
    }

    private bool inExit(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, exitLayer);
        return raycastHit.collider != null;
    }
}

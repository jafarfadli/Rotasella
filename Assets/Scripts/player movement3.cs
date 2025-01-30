using UnityEngine;

public class PlayerMovement3 : MonoBehaviour{
    [SerializeField] private float speed;
    [SerializeField] private Transform leftButton;
    [SerializeField] private Transform rightButton;
    [SerializeField] private Transform leftStartingPoint;
    [SerializeField] private Transform rightStartingPoint;   
    [SerializeField] private LayerMask exitLayer;
    [SerializeField] private string nextScene;
    [SerializeField] private GameObject buttonLeft;
    [SerializeField] private GameObject buttonRight;
    [SerializeField] private float jumpPower;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider2D;
    private Animator anim;
    [SerializeField] private Keycardobtain keycardobtain;
    [SerializeField] private LayerMask groundLayer;

    public bool win {get; private set;}

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");
        if (leftInput() > 0 && leftButton.position == leftStartingPoint.position){
            int moveIndex = buttonLeft.GetComponent<buttondragleft2>().buttonLeftPos;
            if (moveIndex == 0){
                body.linearVelocity = new Vector2(leftInput() * speed * (-1),body.linearVelocity.y);
                transform.localScale = new Vector3(-1,1,1);
                anim.SetBool("move", true);
            } else if (moveIndex == 1){
                boxCollider2D.size = new Vector2(0.8f, 0.6f);
                anim.SetBool("down", true);
            } else if (moveIndex == 2){
                body.linearVelocity = new Vector2(leftInput() * speed,body.linearVelocity.y);
                transform.localScale = new Vector3(1,1,1);
                anim.SetBool("move", true);
            } else if (moveIndex == 3){
                if (isGrounded()){
                    body.linearVelocity = new Vector2(body.linearVelocity.x, leftInput() * jumpPower);
                }
            }
        }

        if (rightInput() > 0 && rightButton.position == rightStartingPoint.position){
            int moveIndex = buttonRight.GetComponent<buttondragright2>().buttonRightPos;
            if (moveIndex == 0){
                body.linearVelocity = new Vector2(rightInput() * speed,body.linearVelocity.y);
                transform.localScale = new Vector3(1,1,1);
                anim.SetBool("move", true);
            } else if (moveIndex == 1){
                if (isGrounded()){
                    body.linearVelocity = new Vector2(body.linearVelocity.x, rightInput() * jumpPower);
                }
            } else if (moveIndex == 2){
                body.linearVelocity = new Vector2(rightInput() * speed * (-1),body.linearVelocity.y);
                transform.localScale = new Vector3(-1,1,1);
                anim.SetBool("move", true);
            } else if (moveIndex == 3){
                boxCollider2D.size = new Vector2(0.8f, 0.6f);
                anim.SetBool("down", true);
            }
        }
        
        if (horizontalInput == 0) {
            boxCollider2D.size = new Vector2(0.8f, 1.2f);
            transform.rotation = Quaternion.Euler(0,0,0);
            anim.SetBool("down", false);
            anim.SetBool("move", false);
        }

        if (isGrounded()){
            anim.SetBool("grounded",true);
        } else{
            anim.SetBool("grounded",false);
        }

        if (inExit() && keycardobtain.cardObtained){
            win = true;
            gameObject.SetActive(false);
        }
    }

    private bool inExit(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, exitLayer);
        return raycastHit.collider != null;
    }

    private int rightInput(){
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.RightArrow) || horizontalInput > 0){
            return 1;
        } else{
            return 0;
        }
    }

    private int leftInput(){
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || horizontalInput < 0){
            return 1;
        } else{
            return 0;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}

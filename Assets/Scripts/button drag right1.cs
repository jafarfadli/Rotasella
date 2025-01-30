using UnityEngine;

public class buttondragright1 : MonoBehaviour
{
    [SerializeField] private Transform startingPointRight;
    private bool isDraggingRight = false;
    private Vector2 offsetRight;

    public int buttonRightPos {get; private set;}

    void Awake(){
        buttonRightPos = 0;
    }


    void Update(){

        Vector2 mousePositionRight = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hitRight = Physics2D.Raycast(mousePositionRight, Vector2.zero);

            if (hitRight.collider != null && hitRight.collider.gameObject == gameObject)
            {
                isDraggingRight = true;
                Physics2D.IgnoreLayerCollision(11,7,true);
                Destroy(GetComponent<Rigidbody2D>());

                offsetRight = (Vector2)transform.position - mousePositionRight;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDraggingRight)
        {
            isDraggingRight = false;
            Physics2D.IgnoreLayerCollision(11,7,false);

            if (transform.position.y < -2.55f && transform.position != startingPointRight.position){
                transform.position = startingPointRight.position;
                
                float rotationZ = transform.eulerAngles.z;
                if (rotationZ >= 315 || rotationZ < 45)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    buttonRightPos = 0;
                }
                else if (rotationZ >= 45 && rotationZ < 135)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    buttonRightPos = 1;
                }
                else if (rotationZ >= 135 && rotationZ < 225)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    buttonRightPos = 2;
                }
                else if (rotationZ >= 225 && rotationZ < 315)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 270);
                    buttonRightPos = 3;
                }
            } else {
                gameObject.AddComponent<Rigidbody2D>();
                GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }

        if (transform.position.x > 9 || transform.position.x < -9){
            Destroy(GetComponent<Rigidbody2D>());
            transform.position = startingPointRight.position;
        }
        
        if (isDraggingRight)
        {
            transform.position = (Vector3)(mousePositionRight + offsetRight);
        }        
    }
}

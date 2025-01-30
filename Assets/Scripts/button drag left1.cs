using UnityEngine;

public class buttondragleft1 : MonoBehaviour
{
    [SerializeField] private Transform startingPointLeft;
    private bool isDraggingLeft = false;
    private Vector2 offsetLeft;

    public int buttonLeftPos {get; private set;}

    void Awake(){
        buttonLeftPos = 0;
    }

    void Update(){

        Vector2 mousePositionLeft = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(mousePositionLeft, Vector2.zero);

            if (hitLeft.collider != null && hitLeft.collider.gameObject == gameObject)
            {
                isDraggingLeft = true;
                Physics2D.IgnoreLayerCollision(10,7,true);
                Destroy(GetComponent<Rigidbody2D>());

                offsetLeft = (Vector2)transform.position - mousePositionLeft;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDraggingLeft)
        {
            isDraggingLeft = false;
            Physics2D.IgnoreLayerCollision(10,7,false);

            if (transform.position.y < -2.55f && transform.position != startingPointLeft.position){
                transform.position = startingPointLeft.position;

                float rotationZ = transform.eulerAngles.z;
                if (rotationZ >= 315 || rotationZ < 45)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    buttonLeftPos = 0;
                }
                else if (rotationZ >= 45 && rotationZ < 135)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    buttonLeftPos = 1;
                }
                else if (rotationZ >= 135 && rotationZ < 225)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    buttonLeftPos = 2;
                }
                else if (rotationZ >= 225 && rotationZ < 315)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 270);
                    buttonLeftPos = 3;
                }
            } else {
                gameObject.AddComponent<Rigidbody2D>();
                GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }

        if (transform.position.x > 9 || transform.position.x < -9){
            Destroy(GetComponent<Rigidbody2D>());
            transform.position = startingPointLeft.position;
        }

        if (isDraggingLeft)
        {
            transform.position = (Vector3)(mousePositionLeft + offsetLeft);
        }        
    }
}

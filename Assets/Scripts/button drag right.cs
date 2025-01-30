using UnityEngine;

public class buttondragright : MonoBehaviour
{
    [SerializeField] private Transform startingPointRight;
    private bool isDraggingRight = false;
    private Vector2 offsetRight;

    void Update(){

        Vector2 mousePositionRight = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hitRight = Physics2D.Raycast(mousePositionRight, Vector2.zero);

            if (hitRight.collider != null && hitRight.collider.gameObject == gameObject)
            {
                isDraggingRight = true;
                Physics2D.IgnoreLayerCollision(6,7,true);
                Destroy(GetComponent<Rigidbody2D>());

                offsetRight = (Vector2)transform.position - mousePositionRight;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDraggingRight)
        {
            isDraggingRight = false;
            Physics2D.IgnoreLayerCollision(6,7,false);

            if (transform.position.y < -2.55f){
                transform.position = startingPointRight.position;
                transform.rotation = Quaternion.Euler(0, 0, 0);
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

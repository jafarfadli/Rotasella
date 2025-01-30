using UnityEngine;

public class buttondragleft : MonoBehaviour
{
    [SerializeField] private Transform startingPointLeft;
    private bool isDraggingLeft = false;
    private Vector2 offsetLeft;

    void Update(){

        Vector2 mousePositionLeft = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(mousePositionLeft, Vector2.zero);

            if (hitLeft.collider != null && hitLeft.collider.gameObject == gameObject)
            {
                isDraggingLeft = true;
                Physics2D.IgnoreLayerCollision(6,7,true);
                Destroy(GetComponent<Rigidbody2D>());

                offsetLeft = (Vector2)transform.position - mousePositionLeft;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDraggingLeft)
        {
            isDraggingLeft = false;
            Physics2D.IgnoreLayerCollision(6,7,false);

            if (transform.position.y < -2.55f){
                transform.position = startingPointLeft.position;
                transform.rotation = Quaternion.Euler(0, 0, 0);
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

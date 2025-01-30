using UnityEngine;

public class Gravityswitch : MonoBehaviour
{
    [SerializeField] private LayerMask objectLayer;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform ruangan;
    private BoxCollider2D boxCollider2D;

    public bool switched { get; private set; }

    private bool activated;

    void Awake(){
        boxCollider2D = GetComponent<BoxCollider2D>();
        switched = false;
        activated = false;
    }

    void Update(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.up, 0.1f, objectLayer);
        if (raycastHit.collider != null && !activated){
            activated = true;
            switching();
            switched = true;         
        }
    }

    private void switching(){
        if (cameraTransform.rotation == Quaternion.Euler(0,0,0)){
            cameraTransform.rotation = Quaternion.Euler(0,0,180);
            ruangan.transform.rotation = Quaternion.Euler(0,0,180);
        } else{
            cameraTransform.rotation = Quaternion.Euler(0,0,0);
            ruangan.transform.rotation = Quaternion.Euler(0,0,180);
        }
    }
}

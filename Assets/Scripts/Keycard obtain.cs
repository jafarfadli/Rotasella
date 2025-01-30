using UnityEngine;

public class Keycardobtain : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    private BoxCollider2D boxCollider2D;

    public bool cardObtained { get; private set; }

    void Awake()
    { 
        boxCollider2D = GetComponent<BoxCollider2D>();
        cardObtained = false;
    }

    void Update()
    {
        if (detectPlayer()){
            cardObtained = true;
            gameObject.SetActive(false);
        }
    }

    private bool detectPlayer(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, playerLayer);
        return raycastHit.collider != null;
    }
}

using UnityEngine;

public class Platformmovement : MonoBehaviour
{
    [SerializeField] private Transform downPoint;
    [SerializeField] private Transform upPoint;
    [SerializeField] private float speed;
    private Vector3 currentPosition;
    void Update(){
        transform.position = Vector3.Lerp(transform.position, currentPosition, speed * Time.deltaTime);
    }
    public void moveUp(){
        currentPosition = upPoint.position;
    }
    public void moveDown(){
        currentPosition = downPoint.position;
    }
}

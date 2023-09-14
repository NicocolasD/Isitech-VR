using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject stone1;
    public GameObject stone2;
    public GameObject stone3;

    public GameObject socle1;
    public GameObject socle2;
    public GameObject socle3;
    
    bool doorIsOpen = false;

    public Transform doorTransform;

    public float openAngle = 90.0f;
    

    void Update()
    {
        if (IsTouchingSocle(stone1, socle1) && IsTouchingSocle(stone2, socle2) && IsTouchingSocle(stone3, socle3) && !doorIsOpen)
        {
            OpenDoor();
        }else if((!IsTouchingSocle(stone1, socle1) || !IsTouchingSocle(stone2, socle2) || !IsTouchingSocle(stone3, socle3)) && doorIsOpen)
        { 
            CloseDoor();
        }
    }

    bool IsTouchingSocle(GameObject stone, GameObject socle)
    {
        Collider stoneCollider =  stone.GetComponent<Collider>();
        Collider socleCollider =  socle.GetComponent<Collider>();
         
        if(stoneCollider.bounds.Intersects(socleCollider.bounds))
        {
            return true;
        }
          
        return false;
    }

    void OpenDoor()
    {
        doorTransform.Rotate(Vector3.up,openAngle);
        doorIsOpen = true;
    }

    void CloseDoor()
    {
        doorTransform.Rotate(Vector3.up, -openAngle);
        doorIsOpen = false;
    }
}

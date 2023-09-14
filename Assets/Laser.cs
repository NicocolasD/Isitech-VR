using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Laser : MonoBehaviour
{
    public GameObject emmeteur1;
    public Transform recepteur1;

    public GameObject emmeteur2;
    public Transform recepteur2;

    public LayerMask layermask;

    bool doorIsOpen = false;
    public Transform doorTransform;
    public float openAngle = 90.0f;

    // Update is called once per frame
    void Update()
    {
        SendRay();
    }

    private void SendRay()
    {
        TraceLaser(emmeteur1, recepteur1);
        TraceLaser(emmeteur2, recepteur2);

        if (LaserBlocked(emmeteur1, recepteur1) && LaserBlocked(emmeteur2, recepteur2) && !doorIsOpen)
        {
            OpenDoor();
        }
        else if ((!LaserBlocked(emmeteur1, recepteur1) || !LaserBlocked(emmeteur2, recepteur2)) && doorIsOpen)
        {
            CloseDoor();
        }



    }

    private bool LaserBlocked(GameObject emmeteur, Transform recepteur)
    {
        Vector3 rayDirection = recepteur.position - emmeteur.transform.position;
        Physics.Raycast(emmeteur.transform.position, rayDirection, out RaycastHit hit, Mathf.Infinity, layermask);
        if (hit.collider.name != recepteur.name)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void TraceLaser(GameObject emmeteur, Transform recepteur)
    {
        Vector3 rayDirection = recepteur.position - emmeteur.transform.position;
        Physics.Raycast(emmeteur.transform.position, rayDirection, out RaycastHit hit, Mathf.Infinity, layermask);

        emmeteur.GetComponent<LineRenderer>().SetPosition(0, emmeteur.transform.position);
        emmeteur.GetComponent<LineRenderer>().SetPosition(1, hit.point);

    }

    void OpenDoor()
    {
        doorTransform.Rotate(Vector3.up, openAngle);
        doorIsOpen = true;
    }


    void CloseDoor()
    {
        doorTransform.Rotate(Vector3.up, -openAngle);
        doorIsOpen = false;
    }
}

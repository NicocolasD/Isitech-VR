using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptacleTriggerSalle2 : MonoBehaviour
{
    public GameObject Socle1; // La porte � ouvrir
    public GameObject Socle2; // La porte � ouvrir
    public GameObject Socle3; // La porte � ouvrir

    public GameObject door; // La porte � ouvrir
    public float doorOpenHeight = 5f; // Hauteur de l'ouverture de la porte
    public float openSpeed = 2f; // Vitesse d'ouverture de la porte
    private bool isDoorOpening = false;
    private Vector3 initialDoorPosition;
    private Vector3 openDoorPosition;

    private void Start()
    {
        if (door == null)
        {
            Debug.LogError("Door object is not assigned!");
            return;
        }

        initialDoorPosition = door.transform.position;
        openDoorPosition = new Vector3(door.transform.position.x, door.transform.position.y + doorOpenHeight, door.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Assurez-vous de tagger l'objet qui doit d�clencher le r�ceptacle avec "TriggerObject"
        if (Socle1.GetComponent<Collider>().CompareTag("Salle2Trigger1") && Socle2.GetComponent<Collider>().CompareTag("Salle2Trigger2") && Socle3.GetComponent<Collider>().CompareTag("Salle2Trigger3"))
        {
            
            isDoorOpening = true;
        }
    }

    private void Update()
    {
        if (isDoorOpening)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, openDoorPosition, openSpeed * Time.deltaTime);

            if (door.transform.position == openDoorPosition)
            {
                isDoorOpening = false;
            }
        }
    }
}
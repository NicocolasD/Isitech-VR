using UnityEngine;

public class SupportTrigger : MonoBehaviour
{
    public GameObject correctObject; // L'objet correct qui doit �tre plac� sur ce support
    public DoorController doorController; // R�f�rence au contr�leur de porte

    [HideInInspector]
    public bool isCorrectObjectPlaced = false; // Si l'objet correct est plac� sur ce support

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == correctObject)
        {
            isCorrectObjectPlaced = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == correctObject)
        {
            isCorrectObjectPlaced = false;
        }
    }
}
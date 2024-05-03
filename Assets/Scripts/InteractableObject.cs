using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool isOpen = false;
    public Vector3 openPosition;
    public Vector3 closePosition;

    public Quaternion openRotation;
    public Quaternion closeRotation;
    public float openSpeed = 1.5f;

    public void Interact()
    {
        // Define interaction behavior here (e.g., open a door, pick up an item, etc.)
        Debug.Log("Interacting with " + gameObject.name);
        
        // if the object is a box lid, move it
        if (gameObject.name == "BoxLid")
        {
            isOpen =! isOpen;
            if (isOpen)
            {
                OpenLid();
            }
            else
            {
                CloseLid();
            }
        }
        if (gameObject.name == "SkullCaveDoor"){
            isOpen =! isOpen;
            if (isOpen)
            {
                OpenLid();
            }
            else
            {
                CloseLid();
            }
        }
    }

    void OpenLid(){
        StartCoroutine(MoveLid(transform.localPosition, openPosition, transform.localRotation, openRotation));
    }
    
    void CloseLid(){
        StartCoroutine(MoveLid(transform.localPosition, closePosition, transform.localRotation, closeRotation));
    }

    IEnumerator MoveLid(Vector3 startPosition, Vector3 targetPosition, Quaternion startRotation, Quaternion targetRotation)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < 1.0f)
        {
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
            transform.localRotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime * openSpeed;
            yield return null;
        }
    }

}


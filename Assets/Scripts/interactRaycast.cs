using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactRaycast : MonoBehaviour
{
    void Update(){
    // Check for mouse click or touch input
    if (Input.GetMouseButtonDown(0)) // Change to appropriate input method
    {
        // Raycast from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Change to touch position for mobile

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            // Check if the ray hits an interactable object
            InteractableObject interactableObject = hitInfo.collider.GetComponent<InteractableObject>();
            if (interactableObject != null)
            {
                // Call the interaction method on the interactable object
                interactableObject.Interact();
            }
        }
    }
}
}



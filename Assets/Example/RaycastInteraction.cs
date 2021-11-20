using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{

    public Camera cam;

    RaycastHit hit;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0) &&
            Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            IInteractable interactable = hit.transform.GetComponent<IInteractable>();
            if (interactable != null)
                interactable.Interact();
        }
    }
}

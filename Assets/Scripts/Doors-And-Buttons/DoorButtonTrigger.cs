using UnityEngine;

namespace DoorsAndButtons
{
    public class DoorButtonTrigger : MonoBehaviour
    {

        public bool interactOnExit;
        public DoorButtonBase doorButton;

        void OnTriggerEnter(Collider other)
        {
            if (doorButton.WhoPressesButton == null)
            {
                doorButton.WhoPressesButton = other;// preventing multiple presses
                doorButton.Interact();
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other == doorButton.WhoPressesButton)
            {
                doorButton.WhoPressesButton = null; // allow button to be pressed again
                if (interactOnExit)
                    doorButton.Interact();
            }
        }
    }
}
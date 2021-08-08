using UnityEngine;

namespace DoorsAndButtons
{
    public class DoorManager : MonoBehaviour
    {

        public Door[] doors;
        public DoorButtonBase[] doorButtons;

        bool opened;

        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < doorButtons.Length; i++)
            {
                doorButtons[i].AddDoorManager(this);
            }
        }

        /// <summary>
        /// Checks if all buttons were activated
        /// </summary>
        public void CheckButtonsState()
        {
            for (int i = 0; i < doorButtons.Length; i++)
            {
                if (!doorButtons[i].IsActivated) // one of the buttons is not activated
                {
                    if (opened) //doors were opened before
                    {
                        ChangeDoorsState(false);// reset doors to default state if one of the buttons is not activated
                        opened = false;
                        return;
                    }
                    else return;
                }
                else if (i == doorButtons.Length - 1 && !opened)//all buttons are activated and doors weren't opened
                {
                    ChangeDoorsState(true); // change doors' states
                    opened = true;
                }
            }
        }

        /// <summary>
        /// Opens/closes the door
        /// </summary>
        /// <param name="state">false - reset to default state, true - change state</param>
        void ChangeDoorsState(bool state)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].ChangeState(state);
            }
        }
    }
}
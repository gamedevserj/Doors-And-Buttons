namespace DoorsAndButtons
{
    public class DoorButtonSwitch : DoorButtonBase
    {

        public bool activeAtStart;
        public DoorButtonBase[] affectedButtons; // buttons that are affected by this button
        void Start()
        {
            IsActivated = activeAtStart;
            base.SetupOnStart();
        }

        public override void Interact()
        {
            AffectButtons(); // affecting other switch buttons dependent on this one
            IsActivated = !IsActivated; // change button status
            ChangeVisualState(IsActivated);
            for (int i = 0; i < doorManagers.Count; i++)
            {
                doorManagers[i].CheckButtonsState();
            }
        }

        /// <summary>
        /// Changes the state of affected buttons
        /// </summary>
        void AffectButtons()
        {
            for (int i = 0; i < affectedButtons.Length; i++)
            {
                affectedButtons[i].Interact(); // change other buttons that can be affected by this one
            }
        }
    }
}
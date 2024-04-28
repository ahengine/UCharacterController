using UCharacterControllerSystem.Modules;
using UnityEngine;

namespace UCharacterControllerSystem.Samples.Movement
{
    [RequireComponent(typeof(UCharacterController))]
    public class PlayerInput : MonoBehaviour
    {
        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string VERTICAL_AXIS = "Vertical";

        private MovementModule movementModule;

        private void Start() =>
            movementModule = GetComponent<UCharacterController>().GetModule<MovementModule>();
        

        private void Update() =>
            movementModule.Move(new Vector2(Input.GetAxis(HORIZONTAL_AXIS),Input.GetAxis(VERTICAL_AXIS)));
    }
}
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
        private GravityModule gravityModule;

        private void Start() 
        {
            var cc = GetComponent<UCharacterController>();
            movementModule = cc.GetModule<MovementModule>();
            gravityModule = cc.GetModule<GravityModule>();
        }
        

        private void Update() 
        {
            movementModule.Move(new Vector2(Input.GetAxis(HORIZONTAL_AXIS),Input.GetAxis(VERTICAL_AXIS)));
            
            if(Input.GetKeyDown(KeyCode.Space))
                gravityModule.DoJump();
        }
    }
}
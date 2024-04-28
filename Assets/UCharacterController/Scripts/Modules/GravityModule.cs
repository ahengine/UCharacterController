using UnityEngine;

namespace UCharacterControllerSystem.Modules
{
    public class GravityModule : UCharacterControllerModule
    {
        [SerializeField] private float jumpForce = 5;
        [SerializeField] private float gravitySpeed = 50;

        [SerializeField] private LayerMask groundLayer;

        public bool IsGrounded =>
            Physics.Raycast(owner.transform.position,Vector3.down,owner.CC.height * .55f ,groundLayer);

        private float currentGravity;

        public override void Process()
        {
            base.Process();

            currentGravity = 
                currentGravity >= 0 && IsGrounded ? 0 : // I'm on Floor
                (currentGravity + gravitySpeed * Time.deltaTime); // I'm in the Air
            owner.CC.Move(Vector3.down * currentGravity * Time.deltaTime);
        }

        public void DoJump() 
        {
            if(!IsGrounded)
                return;

            currentGravity -= jumpForce;
        }

    }
}

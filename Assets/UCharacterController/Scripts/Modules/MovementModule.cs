using UnityEngine;

namespace UCharacterControllerSystem.Modules
{
    public class MovementModule : UCharacterControllerModule
    {
        [SerializeField] private float moveSpeed = 5;
        [SerializeField] private float rotateSpeed = 50;

        public void Move(Vector2 move) 
        {
            owner.CC.Move(owner.transform.forward * move.y * moveSpeed * Time.deltaTime);
            owner.transform.Rotate(new Vector3(0,1,0) * move.x * rotateSpeed * Time.deltaTime);
        }
    }
}

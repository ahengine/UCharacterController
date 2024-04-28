using UnityEngine;

namespace UCharacterControllerSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class UCharacterController : MonoBehaviour
    {
        public CharacterController CC {private set; get;}

        [SerializeField] private UCharacterControllerModule[] modules;

        public T GetModule<T>() where T:UCharacterControllerModule
        {
            for(int i=0;i<modules.Length;i++)
                if(modules[i] is T)
                    return modules[i] as T;
            return null;
        }
        
        private void Awake() {
            CC = GetComponent<CharacterController>();

            for(int i=0;i<modules.Length;i++)
                modules[i].SetOwner(this);
        }

        private void Update()
        {
            for(int i=0;i<modules.Length;i++)
                if(modules[i].IsActive)
                    modules[i].Process();     
        }  
    }
}

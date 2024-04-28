using UnityEngine;

public abstract class Module<TOwner,TModule> : MonoBehaviour where TOwner: MonoBehaviour where TModule: Module<TOwner,TModule>
{
    protected TOwner owner;
    public void SetOwner(TOwner owner) =>
        this.owner = owner;

    [SerializeField] protected TModule[] dependenciesModule;
    [field:SerializeField] public bool IsActive {protected set; get;}

    protected virtual bool DependeniesActivate 
    {
        get 
        {
            for(int i=0;i<dependenciesModule.Length;i++)
                if(dependenciesModule[i].IsActive)
                    return true;

                return false;
        }
    }

    public virtual void Activate() {}
    public virtual void Process() {}
    public virtual void Deactivate() {}
}

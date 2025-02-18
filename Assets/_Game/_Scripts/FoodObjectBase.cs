using UnityEngine;

public class FoodObjectBase : MonoBehaviour, IInteractable
{
    [SerializeField] protected FoodMachineScriptableObject _foodMachineScriptableObject;

    protected FoodType _foodType;
    protected int _foodAmount = 0;
    protected float _productionDuration = 0;
    protected bool _isBroken = false;

    private void Awwake()
    {
        _foodType = _foodMachineScriptableObject.GetFoodType();
        _productionDuration = _foodMachineScriptableObject.GetProductionTime(1); //Upgrade sistemi entegre edildikten sonra burayi degistirecegiz.
    }

    public virtual void Interact()
    {

    }

    public virtual void ToggleHighlight(bool value)
    {

    }

    protected virtual void TakeFood()
    {

    }

    public virtual FoodType GetFoodType()
    {
        return _foodType;
    }

    public virtual int GetFoodAmount()
    {
        return _foodAmount;
    }

    public virtual void Break()
    {
        _isBroken = true;
    }

    public virtual void Fix()
    {
        _isBroken = false;
    }

    public virtual bool IsBroken()
    {
        return _isBroken;
    }
}

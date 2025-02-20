using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodObjectBase : MonoBehaviour, IInteractable
{
    [SerializeField] protected FoodMachineScriptableObject _foodMachineScriptableObject;
    [SerializeField] protected Image _progressBarImage;
    [SerializeField] protected TextMeshProUGUI _foodAmountText;

    protected FoodType _foodType;
    protected float _productionPhase = 0;
    protected float _productionCost = 0;
    protected int _foodAmount = 0;
    protected bool _isBroken = false;

    private void Awake()
    {
        _foodType = _foodMachineScriptableObject.GetFoodType();
        _productionCost = _foodMachineScriptableObject.GetProductionCost(1); //Upgrade sistemi entegre edildikten sonra burayi degistirecegiz.
    }

    public virtual void Interact() { }

    public virtual void PickUp() { }

    public virtual void ToggleHighlight(bool value) { }

    protected virtual void ProduceFood() { }

    protected virtual void TakeFood() { }

    protected virtual void TryFix()
    {
        _isBroken = false;
        UpdateProgressBar();
    }

    protected virtual void UpdateFoodAmountText()
    {
        _foodAmountText.text = _foodAmount.ToString();
    }

    protected virtual void UpdateProgressBar()
    {
        _progressBarImage.fillAmount = _productionPhase / _productionCost;
    }

    protected void Punch()
    {
        transform.DOKill();
        transform.localScale = Vector3.one;
        transform.DOPunchScale(Vector3.one * 0.1f, 0.25f);
    }

    public virtual void Break()
    {
        _isBroken = true;
    }

    public virtual void Fix()
    {
        _isBroken = false;
    }

    public virtual FoodType GetFoodType()
    {
        return _foodType;
    }

    public virtual int GetFoodAmount()
    {
        return _foodAmount;
    }

    public virtual bool GetIsBroken()
    {
        return _isBroken;
    }
}

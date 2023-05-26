using System;
using UnityEngine;

public class ItemEntity : MonoBehaviour
{
    [SerializeField]
    public ItemData ItemData;

    private int _stackAmount;
    private float _pickeupTime;

    public int StackAmount
    {
        get => _stackAmount;
        set
        {
            _stackAmount = Math.Clamp(value, 0, ItemData.StackSize);
            if (StackAmount <= 0) Destroy(this);
        }
    }

    private void Start()
    {
        _pickeupTime = Time.time + 1;   
    }

    public void Stack(ItemEntity other)
    {
        if (other.ItemData.ID != ItemData.ID) return;
        int amount = StackAmount + other.StackAmount;
        StackAmount = amount;
        other.StackAmount = amount - ItemData.StackSize; 
    }    
}

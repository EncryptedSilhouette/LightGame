using System;
using UnityEngine;

public class ItemEntity : MonoBehaviour
{
    [SerializeField]
    public Item Item;

    private float _pickeupTime;

    public int StackAmount
    {
        get => Item.StackSize;
        set
        {
            Item.Amount = Math.Clamp(value, 0, Item.StackSize);
            if (StackAmount <= 0) Destroy(this);
        }
    }

    private void Start()
    {
        _pickeupTime = Time.time + 1;   
    }

    public void Stack(ItemEntity other)
    {
        if (other.Item.ID != Item.ID) return;
        int amount = StackAmount + other.StackAmount;
        StackAmount = amount;
        other.StackAmount = amount - Item.StackSize; 
    }    
}

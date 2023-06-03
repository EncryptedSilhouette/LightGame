using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _itemSlot;
    [SerializeField]
    private Inventory _inventory;

    private ItemSlotUI[] _itemSlots;

    void Start()
    {
        _itemSlots = new ItemSlotUI[_inventory.InventorySize.GetInventorySlots()];

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

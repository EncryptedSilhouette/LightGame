using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField]
    public bool PickUpItems = true;
    [SerializeField]
    public float PickUpRange = 1.0f;    

    private Inventory _inventory;

    void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PickUpItems) Collect();
    }

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, PickUpRange);
    }

    private void Collect()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.transform.position, PickUpRange, LayerMask.GetMask("Item")))
        {
            //collider.GetComponent<ItemEntity>()?.
        }
    }
}


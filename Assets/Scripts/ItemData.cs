using UnityEngine;

[CreateAssetMenu(menuName = "Entities/Items")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private int _stackSize;
    [SerializeField]
    private string _id;
    [SerializeField]
    private Sprite _itemSprite;

    public int StackSize => _stackSize;
    public string ID => _id;
    public Sprite ItemSprite => _itemSprite;
}

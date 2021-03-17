
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNumberTxt;
    [SerializeField] private Image itemImg;

    public InventoryItem thisItem;
    public InventoryManager thisManager;

    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem)
        {
            itemImg.sprite = thisItem.itemImg;
            itemNumberTxt.text = "" + thisItem.numberOfItems;
        }
    }

    public void isClicked()
    {
        if (thisItem)
        {
            thisManager.setDescAndBtn(thisItem.itemDesc, thisItem.usable);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
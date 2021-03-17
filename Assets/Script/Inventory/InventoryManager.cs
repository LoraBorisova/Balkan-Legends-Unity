using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    public PlayerInventory playerInventory;
    [SerializeField] private GameObject emptySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descTxt;
    [SerializeField] private GameObject useBtn;

    public void SettxtAndBtn(string description, bool btnIsActive)
    {
        descTxt.text = description;
        if (btnIsActive)
        {
            useBtn.SetActive(true);
        }
        else
        {
            useBtn.SetActive(false);
        }
    }

    void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                GameObject temp = Instantiate(emptySlot, inventoryPanel.transform.position, Quaternion.identity);
                temp.transform.SetParent(inventoryPanel.transform);
                InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                if (newSlot)
                {
                    newSlot.Setup(playerInventory.myInventory[i], this);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeInventorySlots();
        SettxtAndBtn("", false);
    }

    // Update is called once per frame
    public void setDescAndBtn(string newDesc, bool btnIsUsable)
    {
        descTxt.text = newDesc;
        useBtn.SetActive(btnIsUsable);
    }
}
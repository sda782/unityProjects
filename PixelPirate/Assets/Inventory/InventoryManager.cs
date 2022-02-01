using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<Slot> _inventory;

    public List<Slot> Inventory { get => _inventory; }
    void Start()
    {
        _inventory = new List<Slot>();
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    public static event Action<InventoryLocation, List<InventoryItem>> UpdateInventoryUI;
    public static void CallUpdateInventoryUI(InventoryLocation location, List<InventoryItem> list)
    {
        //若UpdateInventoryUI不为空则Invoke
        UpdateInventoryUI?.Invoke(location, list);
    }

    public static event Action<int, Vector3, int> InstantiateItemInScene;
    public static void CallInstantiateItemInScene(int ID, Vector3 pos, int amount)
    {
        InstantiateItemInScene?.Invoke(ID, pos, amount);

    }
}

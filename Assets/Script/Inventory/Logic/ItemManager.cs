using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFarm.Inventory
{
    public class ItemManager : MonoBehaviour
    {
        //拿到itemBase这个Prefab
        public Item itemPrefab;
        private Transform itemParent;

        void Start()
        {
            itemParent = GameObject.FindWithTag("ItemParent").transform;
        }
        private void OnEnable()
        {
            EventHandler.InstantiateItemInScene += OnInstantiateItemInScene;
        }

        private void OnDisable()
        {
            EventHandler.InstantiateItemInScene -= OnInstantiateItemInScene;
        }


        private void OnInstantiateItemInScene(int ID, Vector3 pos, int amount)
        {
            var item = Instantiate(itemPrefab, pos, Quaternion.identity, itemParent);
            item.itemID = ID;
            item.amount = amount;
        }
    }
}


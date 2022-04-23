using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFarm.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        [Header("物品数据")]
        public ItemDataList_SO itemDataList_SO;
        [Header("背包数据")]
        public InventoryBag_SO playerBag;
        /// <summary>
        /// 通过ID返回物品信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>

        private void Start()
        {
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
        }

        /// <summary>
        /// 通过ID返回物品信息
        /// </summary>
        /// <param name="ID">ItemID</param>
        /// <returns></returns>
        public ItemDetails GetItemDetails(int ID)
        {
            return itemDataList_SO.itemDetailsList.Find(i => i.itemID == ID);
        }

        /// <summary>
        /// 添加物品到玩家背包
        /// </summary>
        /// <param name="item"></param>
        /// <param name="toDestroy"></param>
        public void AddItem(Item item, bool toDestroy)
        {
            //背包是否已经有该物品
            int index = GetItemIndexInBag(item.itemID);

            toDestroy = AddItemAtIndex(item.itemID, index, item.amount);


            Debug.Log(GetItemDetails(item.itemID).itemID + "Name:" + GetItemDetails(item.itemID).itemName);
            if (toDestroy)
            {
                Destroy(item.gameObject);
            }

            //更新UI
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
        }

        /// <summary>
        /// 如果背包有空位返回第一个空位。否则返回-1
        /// </summary>
        /// <returns></returns>
        private int CheckBagCapacity()
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemAmount == 0)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 若背包有该ID的物品，返回位置，否则返回-1
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private int GetItemIndexInBag(int ID)
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemID == ID)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 在指定位置添加物品,添加成功返回true
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="index"></param>
        /// <param name="amount"></param>
        private bool AddItemAtIndex(int ID, int index, int amount)
        {
            InventoryItem item = new InventoryItem { itemID = ID, itemAmount = amount };
            //没有该物品
            if (index == -1)
            {
                int emptyPos = CheckBagCapacity();
                //背包不满
                if (emptyPos != -1)
                {
                    playerBag.itemList[emptyPos] = item;
                    return true;
                }
            }
            else //有该物品
            {
                int currentAmount = playerBag.itemList[index].itemAmount + amount;
                item.itemAmount = currentAmount;
                playerBag.itemList[index] = item;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Player背包范围内交换物品
        /// </summary>
        /// <param name="fromIndex">源物品序号</param>
        /// <param name="targetIndex">目标物品序号</param>
        public void SwapItem(int fromIndex, int targetIndex)
        {
            InventoryItem currentItem = playerBag.itemList[fromIndex];
            InventoryItem targetItem = playerBag.itemList[targetIndex];
            //目标处有物品
            if (targetItem.itemID != 0)
            {
                playerBag.itemList[fromIndex] = targetItem;
                playerBag.itemList[targetIndex] = currentItem;
            }
            else
            {
                playerBag.itemList[fromIndex] = new InventoryItem();
                playerBag.itemList[targetIndex] = currentItem;
            }
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
        }
    }
}


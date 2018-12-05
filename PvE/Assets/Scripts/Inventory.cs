//using UnityEngine;
//using UnityEngine.UI;
//public class Inventory : MonoBehaviour
//{
//    public Sprite [] sprites = Resources.LoadAll<Sprite>("sprites");
//    public Sprite [] slots = new Sprite[numItemSlots];
//    //public Item[] items = new Item[numItemSlots];
//    public const int numItemSlots = 2;
//    public void AddItem( int weapon )
//    {
//        for (int i = 0; i < sprites.Length; i++)
//        {
//            if (slots[i] == null)
//            {
//                if(weapon == 1)
//                {
//                    slots[i] = FindImage("gun_*");
//                    //slots[i].enabled = true;
//                    return;
//                }
//                else
//                {
//                    slots[i] = FindImage("sword_*");
//                    //slots[i].enabled = true;
//                    return;
//                }

//            }
//        }
//    }


//    public Sprite FindImage( string weapon ) { 
//        for(int i = 0; i < sprites.Length; i++)
//        {
//            if (sprites[i].name == weapon)
//            {
//                return sprites[i];
//            }
//        }
//        return null;
//    }
//    //public void RemoveItem(Item itemToRemove)
//    //{
//    //    for (int i = 0; i < items.Length; i++)
//    //    {
//    //        if (items[i] == itemToRemove)
//    //        {
//    //            items[i] = null;
//    //            itemImages[i].sprite = null;
//    //            itemImages[i].enabled = false;
//    //            return;
//    //        }
//    //    }
//    //}
//}
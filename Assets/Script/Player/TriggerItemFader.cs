using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerItemFader : MonoBehaviour
{
    //fade
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemFader[] faders = collision.GetComponentsInChildren<ItemFader>();

        if(faders.Length > 0)
        {
            foreach(ItemFader fader in faders)
            {
                fader.FadeOut();
            }
        }
    }

    //resume
    private void OnTriggerExit2D(Collider2D collision)
    {
        ItemFader[] faders = collision.GetComponentsInChildren<ItemFader>();

        if (faders.Length > 0)
        {
            foreach (ItemFader fader in faders)
            {
                fader.FadeIn();
            }
        }
    }
}

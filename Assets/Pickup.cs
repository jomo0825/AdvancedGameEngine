using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats.Examples;

public class Pickup : MonoBehaviour
{
    public EquippableItem itemPrefab    ;

    private void OnTriggerEnter(Collider other)
    {
        MyCharacter my = other.GetComponent<MyCharacter>();
        if (my == null)
        {
            return;
        }
        my.inv.AddItem(itemPrefab);
        Destroy(gameObject);
        // Explode particle here.
    }
}

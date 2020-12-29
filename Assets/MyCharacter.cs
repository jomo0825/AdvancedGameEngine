using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats.Examples;

public class MyCharacter : MonoBehaviour
{
    public EquippableItem itemPrefab1;
    public Inventory inv;
    public GameObject invCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            invCanvas.SetActive(!invCanvas.activeSelf);
        }

        if (Input.GetKeyDown("1"))
        {
            inv.AddItem(itemPrefab1);
        }

        if (Input.GetKeyDown("2"))
        {
            inv.RemoveItem(itemPrefab1);
        }

        if (Input.GetKeyDown("3"))
        {
            if(inv.SearchItem(itemPrefab1) == true)
            {
                print("you got MySword");
            }
            else
            {
                print("you don't have MySword.");
            }
        }
    }
}

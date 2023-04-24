using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/* This object manages the inventory UI. */

public class InventoryUI : MonoBehaviour {

	public GameObject inventoryUI;	// The entire UI
	//public Transform itemsParent;	// The parent object of all the items

	Inventory inventory;	// Our current inventory

	void Start ()
	{
	}

	// Check to see if we should open/close the inventory
	void Update ()
	{
		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
	}

}

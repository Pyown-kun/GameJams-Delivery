using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManagement : MonoBehaviour
{
    [SerializeField] private int maxItem;

    public GameObject ObjectivePlace;
    public GameObject ObjectivePlaceClose;
    public int itemTotal;

    public Text ItemText;

    private void Update()
    {
        ItemText.text = itemTotal + "/" + maxItem;

        if (itemTotal == maxItem)
        {
            ObjectivePlace.SetActive(true);
            ObjectivePlaceClose.SetActive(false);
        }
    }

    public void AddItem(int item)
    {
        itemTotal += item;
    }
}

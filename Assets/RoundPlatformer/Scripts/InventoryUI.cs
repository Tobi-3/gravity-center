using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    private TextMeshProUGUI spareparttext;
    // Start is called before the first frame update
    void Start()
    {
        spareparttext = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateSparePartText(PlayerInventory playerInventory)
    {
        spareparttext.text = playerInventory.NumberOfParts.ToString();
    }

}

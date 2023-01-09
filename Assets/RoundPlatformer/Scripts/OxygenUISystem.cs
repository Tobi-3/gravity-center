using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenUISystem : MonoBehaviour
{
    [SerializeField] private OxygenSystem _oxygenSystem;

    [SerializeField] private Image _oxygenBar;

    [SerializeField] private TextMeshProUGUI _oxygenPercentage;

    private void FixedUpdate() {
        _oxygenBar.fillAmount = _oxygenSystem.oxygenPercentage;
        _oxygenPercentage.text = ((_oxygenSystem.oxygenPercentage)*100).ToString("N0")+"%";
    }
}

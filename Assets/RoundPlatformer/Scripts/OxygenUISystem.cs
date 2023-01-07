using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenUISystem : MonoBehaviour
{
    [SerializeField] private OxygenSystem _oxygenSystem;

    [SerializeField] private Image _oxygenBar;

    private void FixedUpdate() {
        _oxygenBar.fillAmount = _oxygenSystem.oxygenPercentage;
    }
}

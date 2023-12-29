using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUpgradeMenuCheck : MonoBehaviour
{
    [Header("UpgradeCanvas")]
    [SerializeField] private Canvas _UpgradeMenuCanvas;

    public void DecreaseCharmCooldown()
    {
        playerScript.charmCooldown+=.5f;
        _UpgradeMenuCanvas.gameObject.SetActive(false); 
        Time.timeScale = 1;
    }

    public void UpgradeCharmRange()
    {
        playerScript.charmRange+=.5f;
        _UpgradeMenuCanvas.gameObject.SetActive(false); 
        Time.timeScale = 1;
    }

    public void UpgradeSummonHP()
    {
        playerScript.summonBonusHP+=5;
        _UpgradeMenuCanvas.gameObject.SetActive(false); 
        Time.timeScale = 1;
    }

    public void ChooseUpgrade()
    {
       _UpgradeMenuCanvas.gameObject.SetActive(true); 
       Time.timeScale = 0;
    }
}

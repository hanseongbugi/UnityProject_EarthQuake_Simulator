using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshPhotonButton : MonoBehaviour
{
    public Button btnHide;
    public Button btnAttack;
    public cshPhtonPlayerController sPlayer;
    void Start()
    {
        btnHide.gameObject.SetActive(false);
        btnHide.onClick.RemoveAllListeners();
        btnHide.onClick.AddListener(OnClickHideButton);
        btnAttack.gameObject.SetActive(false);
        btnAttack.onClick.RemoveAllListeners();
        btnAttack.onClick.AddListener(OnClickAttackButton);
    }
    void Update()
    {
        UpdateButton();
    }

    private void UpdateButton()
    {
        bool canAttack = sPlayer.CanAttack();
        bool canHide = sPlayer.CanHide();
        Debug.Log(canAttack);
        btnAttack.gameObject.SetActive(canAttack);
        btnHide.gameObject.SetActive(canHide);
    }
    private void OnClickHideButton()
    {
        sPlayer.OnVirtualPadHide();
    }

    private void OnClickAttackButton()
    {
        sPlayer.OnVirtualPadAttack();
    }

}

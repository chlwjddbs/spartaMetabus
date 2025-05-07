using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public TextMeshProUGUI noticeText;

    public void OpenNotice(string notice)
    {
        SetNotice(notice);
        noticeText.gameObject.SetActive(true);
    }

    public void SetNotice(string notice)
    {
        noticeText.text = notice;
    }

    public void CloseNotice()
    {
        noticeText.text = "";
        noticeText.gameObject.SetActive(false);
    }
}

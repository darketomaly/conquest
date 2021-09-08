using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TSMenuItem : MonoBehaviour {

    public CanvasGroup m_cg;
    public Image m_image;
    public TextMeshProUGUI m_tmpro;
    [HideInInspector] public bool m_highlighted;

    private Button btn;

    private void Start() {

        btn = GetComponent<Button>();

        btn.onClick.AddListener(delegate {

            transform.DOPunchScale(0.1f * Vector3.one, 0.1f);
        });
    }

    private void OnDestroy() {

        btn?.DOKill();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuAnimationManager : MonoBehaviour {

    public List<TSMenuItem> items = new List<TSMenuItem>();

    public Color normal;
    public Color highlighted;

    private int highlightedIndex = -1;

    private void Start() {

        GraphicRaycasterManager.onMouseOver += HighlightMenuItem;
        GraphicRaycasterManager.onNothingFound += Dehightlight;
    }

    public void MakeMenuAppear(bool value) {

        for (int i = 0; i < items.Count; i++)
            items[i].m_cg.DOFade(1.0f, 0.5f).SetDelay(i * 0.225f);
    }

    private void HighlightMenuItem(Transform hoveredGraphicElement) {

        for (int i = 0; i < items.Count; i++) {
            
            if(items[i].transform == hoveredGraphicElement) { //

                if(highlightedIndex != i)
                    Dehightlight();

                highlightedIndex = i;

                if (!items[i].m_highlighted) {

                    items[i].m_highlighted = true;
                    items[i].m_image.DOColor(highlighted, 0.15f);
                    items[i].m_tmpro.DOColor(normal, 0.15f);
                }

                break;
            }
        }
    }

    private void Dehightlight() {

        if(highlightedIndex >= 0) {

            items[highlightedIndex].m_highlighted = false;
            items[highlightedIndex].m_image.DOColor(normal, 0.15f);
            items[highlightedIndex].m_tmpro.DOColor(highlighted, 0.15f);
            highlightedIndex = -1;
        }
    }
}

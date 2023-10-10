using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIAnims : MonoBehaviour
{
    public enum UIAnimType
    {
        ArrowIconScalePosAnimOnStart,
        ArrowIconScalePosAnimOnTrigger,

    }

    public UIAnimType uiAnimType;
    private RectTransform _rectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        switch (uiAnimType)
        {
            case UIAnimType.ArrowIconScalePosAnimOnStart:
                ArrowIconScalePosAnimOnStartMethod();
                _rectTransform = GetComponent<RectTransform>();
                break;
        }
    }

    private void ArrowIconScalePosAnimOnStartMethod()
    {
        // transform.DOMove(transform.position - new Vector3(0, 1, 0), 1);
        transform.DOMove(transform.position - new Vector3(0,0.1f,0), 1f).OnComplete(() =>
        {
            transform.DOScale(new Vector3(1,1.35f,1), 0.3f);
            transform.DOMove(transform.position + new Vector3(0,0.1f,0), 0.5f).OnComplete(() =>
            {
                transform.DOScale(Vector3.one, 0.3f).OnComplete(ArrowIconScalePosAnimOnStartMethod);
            });
        });
    }
}

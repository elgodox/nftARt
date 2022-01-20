using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    public Action updateContent;
    private RectTransform contentTransform;
    private float _secondsToTryUpdate = 3;
    private float _currentTime;
    void Start()
    {
        contentTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        
        if (contentTransform.position.y > contentTransform.sizeDelta.y + 300)
        {
            if (_currentTime >= 0)
            {
                _currentTime -= Time.deltaTime * 1;
            }

            if (_currentTime <= 0)
            {
                _currentTime = _secondsToTryUpdate;
                updateContent.Invoke();
            }

        }


    }
}

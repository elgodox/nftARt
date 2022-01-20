using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskButtons : MonoBehaviour
{
    Animator _animator;
    bool _enabled = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Show()
    {
        _enabled = !_enabled;
        if (_animator != null)
        {
            if (_enabled)
                _animator.SetTrigger("Show");
            else
                _animator.SetTrigger("Hide");
        }
    }




}

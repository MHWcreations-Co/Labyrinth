using System;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public ObjectItems objectItems;

    private bool _interactable = false;
    private Renderer _renderer;
    private Character _character;

    private void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        ChangeColor();
    }

    protected virtual void Interact()
    {
        if (objectItems == null)
        {
            return;
        }

        objectItems.Use();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _interactable = true;
            Interact();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) _interactable = false;
    }

    void ChangeColor()
    {
        if (_interactable)
        {
            _renderer.material.SetFloat("_Metallic", 1f);
        }
        else
        {
            _renderer.material.SetFloat("_Metallic", 0);
        }
    }
}
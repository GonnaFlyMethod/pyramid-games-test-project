using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private List<Renderer> _objRenderers;
    [SerializeField] private Color _colorOnHover;

    private List<Color> _defaultColors;
    
    private void Start()
    {
        _defaultColors = new List<Color>();

        Debug.Log(gameObject.name);
        foreach (Renderer renderer in _objRenderers) {
            _defaultColors.Add(renderer.material.color);
        }
    }

    public void OnPointerEnter(PointerEventData _)
    {
        foreach (Renderer renderer in _objRenderers) {
            renderer.material.color = _colorOnHover;
        }
    }

    public void OnPointerExit(PointerEventData _)
    {
        for (int i = 0; i < _objRenderers.Count; i++)
        {
            Renderer renderer = _objRenderers[i];
            Color defaultColorOfRenderer = _defaultColors[i];

            renderer.material.color = defaultColorOfRenderer;
        }
    }
}

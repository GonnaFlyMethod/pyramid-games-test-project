using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogComponents : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProl;
    [SerializeField] private List<Button> _btns;

    public TextMeshProUGUI GetTxtMeshPro(){return _textMeshProl;}
    public List<Button> GetButtons() { return _btns;}
}

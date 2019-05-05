using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Text", fileName = "Text")]
public class TextVR : Scriptables
{
    public TextVR()
    {
        type = Type.Text;
    }

    public GameObject prefabText;
    public string message;
    private TextMesh texto;

    public override void OnNotSeen(GameObject obj)
    {
        ReviewText(obj);
        texto.gameObject.SetActive(false);
    }

    public override void OnSeen(GameObject obj)
    {
        ReviewText(obj);
        texto.gameObject.SetActive(true);
    }

    void ReviewText(GameObject obj)
    {
        if (texto == null)
        {
            texto = Instantiate(prefabText, obj.transform).GetComponent<TextMesh>();
            texto.text = message;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interaction/Text", fileName = "Text")]
public class InteractText : Interactive
{
    public InteractText()
    {
        type = Type.Text;
    }

    public GameObject prefabText;
    public string message;
    private TextMesh textMesh;

    public override void OnNotSeen(GameObject obj)
    {
        CheckTextMesh(obj);
        textMesh.gameObject.SetActive(false);
    }

    public override void OnSeen(GameObject obj)
    {
        CheckTextMesh(obj);
        textMesh.gameObject.SetActive(true);
    }

    void CheckTextMesh(GameObject obj)
    {
        if(textMesh == null)
        {
            textMesh = Instantiate(prefabText, obj.transform).GetComponent<TextMesh>();
            textMesh.text = message;
        }
    }
}

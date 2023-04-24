using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    [SerializeField] private UIParametr prefab;
    private List<Parametr> parametrs = new List<Parametr>();
    [SerializeField] private UnityCreature cr;

    private void Start()
    {
        SetCreature(cr);
    }

    public void SetCreature(UnityCreature creature)
    {
        parametrs = creature.Info();
        int k = 0;
        foreach(Parametr parametr in parametrs)
        {
            GameObject ui = Instantiate<GameObject>(prefab.gameObject, transform);
            RectTransform rect = ui.GetComponent<RectTransform>();
            rect.anchorMax = new Vector2(1, 1 - 0.1f * k);
            rect.anchorMin = new Vector2(0, 1 - 0.1f * (k + 1));
            ui.GetComponent<UIParametr>().SetParametr(parametr);
            k++;
        }
    }
}

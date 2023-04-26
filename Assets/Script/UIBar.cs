using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    [SerializeField] private UIParametr prefab;
    private List<Parametr> parametrs = new List<Parametr>();
    private List<GameObject> UIParametrs = new List<GameObject>();
    [SerializeField] private UnityCreature cr;

    public void SetCreature(UnityCreature creature, bool simulation = false)
    {
        if (UIParametrs.Count > 0)
        {
            foreach(GameObject uiParametr in UIParametrs)
            {
                Destroy(uiParametr);
            }
        }
        if (simulation)
            parametrs = creature.GetSimulationInfo();
        else
            parametrs = creature.GetInfo();

        int k = 0;
        foreach(Parametr parametr in parametrs)
        {
            GameObject ui = Instantiate<GameObject>(prefab.gameObject, transform);
            UIParametrs.Add(ui);
            RectTransform rect = ui.GetComponent<RectTransform>();
            rect.anchorMax = new Vector2(1, 1 - 0.1f * k);
            rect.anchorMin = new Vector2(0, 1 - 0.1f * (k + 1));
            ui.GetComponent<UIParametr>().SetParametr(parametr);
            k++;
        }
    }
}

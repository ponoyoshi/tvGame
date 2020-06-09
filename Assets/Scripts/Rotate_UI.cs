using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Rotate_UI : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed = 40;
    [SerializeField]
    private float addScale = 0.1f;
    [SerializeField]
    private float scaleSpeed = 500;
    private float cosValu = 0;

    private RectTransform Rtrans;
    [SerializeField]
    private RectTransform textScaleTransform;
    private bool PointerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        Rtrans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PointerOn)
        {
            Rtrans.Rotate(new Vector3(0, 0, spinSpeed * Time.deltaTime));
            cosValu += scaleSpeed * Time.deltaTime;
            cosValu %= 360;
            float newScale = 1 + (addScale * (Mathf.Cos((cosValu * Mathf.PI) / 180) + 1) / 2);
            Rtrans.localScale = new Vector3(newScale, newScale,1);
            textScaleTransform.localScale = new Vector3(newScale, newScale, 1);
        }
    }

    public void PointerEnter()
    {
        PointerOn = true;
    }
    public void PointerExit()
    {
        PointerOn = false;
        cosValu = 0;
        Rtrans.localScale = new Vector3(1, 1, 1);
        textScaleTransform.localScale = new Vector3(1, 1, 1);
    }
}

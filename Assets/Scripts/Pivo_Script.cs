using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pivo_Script : MonoBehaviour
{
    [SerializeField] private float div = 2;
    [SerializeField] private Slider pos;
    [SerializeField] private Slider scl;
    [SerializeField] private GameObject[] cams = new GameObject[8];
    [SerializeField] private RenderTexture[] cams_imgs = new RenderTexture[8];
    private RectTransform[] cam = new RectTransform[8];
    [SerializeField] private bool cam_ativas = false;
    [SerializeField] private bool cam_img = false;

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            cam[i] = cams[i].GetComponent<RectTransform>();
        }
        cam[4].gameObject.SetActive(false);
        cam[5].gameObject.SetActive(false);
        cam[6].gameObject.SetActive(false);
        cam[7].gameObject.SetActive(false);
    }

    void Update()
    {
        cam[0].anchoredPosition = new Vector3(-pos.value * scl.value, 0, 0);
        cam[1].anchoredPosition = new Vector3(pos.value * scl.value, 0, 0);
        cam[2].anchoredPosition = new Vector3(0, -pos.value * scl.value, 0);
        cam[3].anchoredPosition = new Vector3(0, pos.value * scl.value, 0);

        cam[0].localScale = new Vector3(scl.value, scl.value, scl.value);
        cam[1].localScale = new Vector3(scl.value, scl.value, scl.value);
        cam[2].localScale = new Vector3(scl.value, scl.value, scl.value);
        cam[3].localScale = new Vector3(scl.value, scl.value, scl.value);

        if (cam_ativas == true)
        {
            cam[4].anchoredPosition = new Vector3(-(pos.value * scl.value) / div, (pos.value * scl.value) / div, 0);
            cam[5].anchoredPosition = new Vector3((pos.value * scl.value) / div, (pos.value * scl.value) / div, 0);
            cam[6].anchoredPosition = new Vector3((pos.value * scl.value) / div, -(pos.value * scl.value) / div, 0);
            cam[7].anchoredPosition = new Vector3(-(pos.value * scl.value) / div, -(pos.value * scl.value) / div, 0);

            cam[4].localScale = new Vector3(scl.value, scl.value, scl.value);
            cam[5].localScale = new Vector3(scl.value, scl.value, scl.value);
            cam[6].localScale = new Vector3(scl.value, scl.value, scl.value);
            cam[7].localScale = new Vector3(scl.value, scl.value, scl.value);
        }
    }
    public void set_cam_act()
    {
        if (cam_ativas == false)
        {
            cam_ativas = true;
            cam[4].gameObject.SetActive(true);
            cam[5].gameObject.SetActive(true);
            cam[6].gameObject.SetActive(true);
            cam[7].gameObject.SetActive(true);
        }
        else
        {
            cam_ativas = false;

            cam[4].gameObject.SetActive(false);
            cam[5].gameObject.SetActive(false);
            cam[6].gameObject.SetActive(false);
            cam[7].gameObject.SetActive(false);
        }
    }
    public void set_img()
    {
        if (cam_img == true)
        {
            cam_img = false;
            for (int i = 0; i < 8; i++)
            {
                cams[i].GetComponent<RawImage>().texture = cams_imgs[2];
            }
        }
        else
        {
            cam_img = true;
            for (int i = 0; i < 8; i++)
            {
                cams[i].GetComponent<RawImage>().texture = cams_imgs[i];
            }
        }
    }
}

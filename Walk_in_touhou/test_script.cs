using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class test_script : MonoBehaviour
{
    public RawImage map;
    [Header("맵 정보")]
    public string strBaseURL = "";
    public double latitude = 35.0;
    public double longitude = 35.0;
    public int zoom = 14;
    public int mapw;
    public int maph;
    public string strAPIkey = "";
    // Start is called before the first frame update
    void Start()
    {
        map = GetComponent<RawImage>();
        StartCoroutine(Loadmap());
    }

    IEnumerator Loadmap(){
        string url = strBaseURL + "center=" + latitude + "," + longitude + "&zoom=" + zoom.ToString() + "&size=" + mapw.ToString() + "x" + maph.ToString() + "&key=" + strAPIkey;
        Debug.Log("URL : " + url);
        url = UnityWebRequest.UnEscapeURL(url); //Url에 대한 Web 요청
        UnityWebRequest req = UnityWebRequestTexture. GetTexture(url); //Textureoll CHat 8
    
        yield return req.SendWebRequest(); //요청 전송
        map.texture = DownloadHandlerTexture. GetContent(req); //
    }

    // Update is called once per frame
    void Update()

    {
        
    }
}

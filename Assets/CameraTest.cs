using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Net;
using System.Text;

public class CameraTest : MonoBehaviour
{
    //摄像头图像类，继承自texture
    WebCamTexture tex;
    public Image WebCam;
    public RawImage bgimage_01;
    public Button saveImage;

    public RawImage bgimage_02;
    // public RawImage bgimage_03;
    int i;
    public Text resultText;
    public Text buttonText;
    bool isPhoto = false;
    void Start()
    {
        //开启协程，获取摄像头图像数据
        StartCoroutine(OpenCamera());
        saveImage.onClick.AddListener(SaveImage);
        bgimage_02.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator OpenCamera()
    {
        //等待用户允许访问
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        //如果用户允许访问，开始获取图像        
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            //先获取设备
            WebCamDevice[] device = WebCamTexture.devices;

            string deviceName = device[0].name;
            //然后获取图像
            tex = new WebCamTexture(deviceName);
            //将获取的图像赋值
            bgimage_01.texture = tex;
            //开始实施获取
            tex.Play();

        }
    }
    private void SaveImage()
    {
        if (isPhoto)
        {

            buttonText.text = "拍照识别";
            bgimage_02.enabled = false;
            resultText.text = "";
            isPhoto = false;
        }
        else
        {
            //在上一段代码中加入该方法
            Save(tex);
            i += 1;
            buttonText.text = "重新拍照";
            isPhoto = true;
        }
       



    }
    public void Save(WebCamTexture t)
    {
        Texture2D t2d = new Texture2D(t.width, t.height, TextureFormat.ARGB32, true);
        //将WebCamTexture 的像素保存到texture2D中
        t2d.SetPixels(t.GetPixels());
        //t2d.ReadPixels(new Rect(200,200,200,200),0,0,false);
        t2d.Apply();
        //编码
        byte[] imageTytes = t2d.EncodeToJPG();
        //if (i % 2 == 1)
        //{
        //   bgimage_02.texture= t2d;
        //}
        //else
        //{
        //    bgimage_03.texture = t2d;
        //}
        bgimage_02.enabled = true;
        bgimage_02.texture = t2d;
        //存储
        //File.WriteAllBytes(Application.streamingAssetsPath + "/my/" + Time.time + ".jpg", imageTytes);
        string strbaser64 = Convert.ToBase64String(imageTytes);


        string host = "https://aip.baidubce.com/rest/2.0/image-classify/v1/animal?access_token=" + "24.d62236a7ae85eb7f42dc4ae6f696250a.2592000.1576320535.282335-17766486";
        Encoding encoding = Encoding.Default;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
        request.Method = "post";
        request.KeepAlive = true;
        // 图片的base64编码
        //string base64 = getFileBase64("[本地图片文件]");
        String str = "image=" + System.Web.HttpUtility.UrlEncode(strbaser64);
        byte[] buffer = encoding.GetBytes(str);
        request.ContentLength = buffer.Length;
        request.GetRequestStream().Write(buffer, 0, buffer.Length);

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
        string result = reader.ReadToEnd();
        print("动物识别:");
        print(result);
        //JSONObject jsonObject = JSONObject.fromObject("json格式的字符串");
        //String jsonStr = "{id:2}";
        //JSONObject jsonObject = JSONObject.fromObject(jsonStr);
        //int id = jsonObject.getInt("id");

        resultText.text = "识别结果：" + result.Split(':')[4].Split('"')[1];
    }

    void StopCamera()
    {
        //等待用户允许访问
        //Application.RequestUserAuthorization(UserAuthorization.WebCam);
        //如果用户允许访问，开始获取图像        
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            //先获取设备
            WebCamDevice[] device = WebCamTexture.devices;

            string deviceName = device[0].name;
            //然后获取图像
            //  tex = new WebCamTexture(deviceName);
            //  //将获取的图像赋值
            // ma.material.mainTexture = tex;
            //开始实施获取
            tex.Stop();


        }
    }
    //返回按钮
    public void Back()
    {
        StopCamera();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

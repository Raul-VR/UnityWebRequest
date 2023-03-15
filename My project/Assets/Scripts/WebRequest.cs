using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using TMPro;

 
public class WebRequest : MonoBehaviour
{

    // void Start()
    // {
    //     StartCoroutine(Upload());
    // }
 
    public IEnumerator Upload(string grupo, string lista)
    {
        WWWForm form = new WWWForm();
        //form.AddField("listNumber", "2");
        form.AddField("group", grupo);
        form.AddField("listNumber", lista);

 
        using (UnityWebRequest www = UnityWebRequest.Post("http://10.48.154.254:8000/login", form))
        {
            yield return www.SendWebRequest();
 
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log("Form upload complete!");
                string txt = www.downloadHandler.text;
                Debug.Log(txt);

                


            }
        }
    }
}

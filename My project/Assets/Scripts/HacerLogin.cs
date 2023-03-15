using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HacerLogin : MonoBehaviour
{


    public TMP_InputField tmp_grupo;
    public TMP_InputField tmp_lista;

    public void Login()
    {
        string group = tmp_grupo.text;
        string listNumber = tmp_lista.text;

        StartCoroutine(Upload(group, listNumber));
    }

     
    IEnumerator Upload(string group, string listNumber)
    {
        WWWForm form = new WWWForm();
        form.AddField("group", group);
        form.AddField("listNumber", listNumber);

        using (UnityWebRequest www = UnityWebRequest.Post("http://10.48.154.254:8000/login", form))
        {
            yield return www.SendWebRequest();

            string level = "";
 
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log("Form upload complete!");
                string txt = www.downloadHandler.text;
                txt = txt.Substring(1);
                txt = txt.Substring(0, txt.Length - 2);
                //Debug.Log(txt);
                User u = JsonUtility.FromJson<User>(txt);
                List<Level> manyLevels = u.history;

                bool isRecent = false;
                int i = 0;

                while (!isRecent && (i < manyLevels.Count)) {

                    if (int.Parse(manyLevels[i].score) == -1 && i > 0) {
                        level = manyLevels[i-1].level;
                        isRecent = true;
                    }
                    else if (i == manyLevels.Count - 1) {
                        level = manyLevels[i].level;
                    }
                    else {
                        level = "NULL";
                    }
                    i++;
                }

                Debug.Log(level);
                
            }
        }


    }


}

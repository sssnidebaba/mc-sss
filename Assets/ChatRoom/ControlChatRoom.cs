using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(AudioSource))]
    public class ControlChatRoom : MonoBehaviour
    {

        public InputField chatInput;
        public Text chatText;
        public ScrollRect scrollRect;
        string username = "4399_xjx";

        public Transform m_Transform;
        private Vector3 Home = new Vector3(0, 62, 2);
        private float duration;

        public WeatherType Clear;
        public WeatherType MostlyClear;
        public WeatherType Rain;
        public WeatherType HeavyRain;
        public WeatherType Snow;
        public WeatherType HeavySnow;
        public WeatherType Thunderstorm;
        public WeatherType Cloudy;

        private bool tplockflag;
        private bool weatherlockflag;
        private bool setnameflag;

        // Use this for initialization
        void Start()
        {
            duration = 0.5f;
            tplockflag = false;
            weatherlockflag = false;
            setnameflag = false;
        }

        // Update is called once per frame
        void Update()
        {
            /*
            if (Input.GetKeyDown("p"))
            {

                GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;

                m_Transform.transform.position = Home;

              //  Invoke(nameof(Lock), duration);


                // GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
            }

            */



            if (!tplockflag && !weatherlockflag &&!setnameflag) 
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {

                    if (chatInput.text == "/clear")
                    {
                        chatText.text = " ";
                        string addText = "\n  " + "<color=red>" + "system" + ": " + "clear!</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();
                    }
                    else if (chatInput.text == "/showWeather")
                    {
                        string CurrentWeatherTypeName = UniStormSystem.Instance.CurrentWeatherType.WeatherTypeName;
                        string addText = "\n  " + "<color=red>" + "system" + ": " + "\nWeather:" + CurrentWeatherTypeName + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();


                    }
                    else if(chatInput.text == "/changeWeather")
                    {
                        string addText = "\n  " + "<color=red>" + "system" + ": " + "\nWeather Which?" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                        weatherlockflag = true;

                    }
                    else if (chatInput.text == "/sethome")
                    {
                        Home = m_Transform.position;

                        string addText = "\n  " + "<color=red>" + "system" + ": " + "\nSethome Succeed!" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                    }
                    else if (chatInput.text == "/setname")
                    {
                        string addText = "\n  " + "<color=red>" + "system" + ": " + "\nSet your name" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                        setnameflag = true;

                    }
                    else if (chatInput.text == "/position")
                    {
                        string addText = "\n  " + "<color=red>" + "system" + ": " + "\nPosition:" + m_Transform.position+"</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();
                    }
                    else if (chatInput.text == "/tp")
                    {
                       // m_Transform.transform.position = Home;
                        string addText = "\n  " + "<color=red>" + "system" + ": " + "\nTP Where?" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                        tplockflag = true;

                    }
                    else if (chatInput.text != "")
                    {

                        string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text;
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();       //关键代码
                        scrollRect.verticalNormalizedPosition = 0f;  //关键代码
                        Canvas.ForceUpdateCanvases();   //关键代码
                    }
                }






            }
            else if(tplockflag)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    if (chatInput.text == "/home")
                    {
                        m_Transform.transform.position = Home;
                        string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text+"\n  " + "<color=red>" + "system" + ": " + "\nTP Succeed！" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                    }
                    else
                    {
                        Vector3 T = Parse(chatInput.text);

                        if (T == m_Transform.position)
                        {
                            string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text+ "\n  " + "<color=red>" + "system" + ": " + "\nTP Fail！" + "</color>";
                            chatText.text += addText;
                            chatInput.text = "";
                            chatInput.ActivateInputField();
                            Canvas.ForceUpdateCanvases();
                            scrollRect.verticalNormalizedPosition = 0f;
                            Canvas.ForceUpdateCanvases();


                        }
                        else
                        {
                            m_Transform.transform.position = T;
                            string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text+"\n  " + "<color=red>" + "system" + ": " + "\nTP Succeed！" + "</color>";
                            chatText.text += addText;
                            chatInput.text = "";
                            chatInput.ActivateInputField();
                            Canvas.ForceUpdateCanvases();
                            scrollRect.verticalNormalizedPosition = 0f;
                            Canvas.ForceUpdateCanvases();
                        }

                    


                    }


                    tplockflag = false;
                }
                


            }

            else if (weatherlockflag)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {

                    if (chatInput.text == "/clear")
                    {

                        UniStormManager.Instance.ChangeWeatherInstantly( Clear);

                        string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text + "\n  " + "<color=red>" + "system" + ": " + "\nWeather:Clear!" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                    }
                    else if (chatInput.text == "/mostlyClear")
                    {

                        UniStormManager.Instance.ChangeWeatherInstantly(MostlyClear);

                        string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text + "\n  " + "<color=red>" + "system" + ": " + "\nWeather:Mostly Clear!" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                    }
                    else if (chatInput.text == "/rain")
                    {

                        UniStormManager.Instance.ChangeWeatherInstantly(Rain);

                        string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text + "\n  " + "<color=red>" + "system" + ": " + "\nWeather:Rain!" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                    }
                    else if (chatInput.text == "/heavyRain")
                    {

                        UniStormManager.Instance.ChangeWeatherInstantly(HeavyRain);

                        string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text + "\n  " + "<color=red>" + "system" + ": " + "\nWeather:Heavy Rain!" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                    }
                    else if (chatInput.text == "/snow")
                    {

                        UniStormManager.Instance.ChangeWeatherInstantly(Snow);

                        string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text + "\n  " + "<color=red>" + "system" + ": " + "\nWeather:Snow!" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                    }
                    else if (chatInput.text == "/heavySnow")
                    {

                        UniStormManager.Instance.ChangeWeatherInstantly(HeavySnow);

                        string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text + "\n  " + "<color=red>" + "system" + ": " + "\nWeather:Heavy Snow!" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                    }
                    else if (chatInput.text == "/thunderstorm")
                    {

                        UniStormManager.Instance.ChangeWeatherInstantly(Thunderstorm);

                        string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text + "\n  " + "<color=red>" + "system" + ": " + "\nWeather:Thunderstorm!" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                    }
                    else if (chatInput.text == "/cloudy")
                    {

                        UniStormManager.Instance.ChangeWeatherInstantly(Cloudy);

                        string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text + "\n  " + "<color=red>" + "system" + ": " + "\nWeather:Cloudy!" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                    }
                    else if (chatInput.text != "")
                    {


                        string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text + "\n  " + "<color=red>" + "system" + ": " + "\nChange Weather Fail！" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                    }


                    weatherlockflag = false;

                }


                    
            }
            else if (setnameflag)
            {

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    if (chatInput.text != "")
                    {

                        username = chatInput.text;
                        string addText = "\n  " + "<color=blue>" + username + "</color>: " + chatInput.text + "\n  " + "<color=red>" + "system" + ": " + "\nSetname Succeed！" + "</color>";
                        chatText.text += addText;
                        chatInput.text = "";
                        chatInput.ActivateInputField();
                        Canvas.ForceUpdateCanvases();
                        scrollRect.verticalNormalizedPosition = 0f;
                        Canvas.ForceUpdateCanvases();

                    }


                    setnameflag = false;
                }

            }








        }

        private void Lock()
        {
            //这里写上duration秒后要执行的内容

            GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;

        }
        public  Vector3 Parse(string str)
        {
            str = str.Replace("(", " ").Replace(")", " "); //将字符串中"("和")"替换为" "
            string[] s = str.Split(',');

            if (s.Length != 3) 
            { 
                return m_Transform.position;



            }

            return new Vector3(float.Parse(s[0]), float.Parse(s[1]), float.Parse(s[2]));





        }




    }



}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(AudioSource))]
    public class cameraSwitch : MonoBehaviour
    {


        public GameObject P1;
        public GameObject P3;

        public GameObject Chat;

        public Transform m_Transform;


        private bool camerastatus = true;
        // Start is called before the first frame update
        void Start()
        {
            P1.SetActive(true);
            P3.SetActive(false);
            Chat.SetActive(false);

        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown("q"))
            {
                if (camerastatus == true)
                {




                    P1.SetActive(false);
                    P3.SetActive(true);
                    camerastatus = false;
                }
                else
                {



                    P1.SetActive(true);
                    P3.SetActive(false);
                    camerastatus = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
                Chat.SetActive(true);


            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Chat.SetActive(false);
                GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;

            }



        }





    }

}
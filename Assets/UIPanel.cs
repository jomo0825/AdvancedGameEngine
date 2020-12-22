using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MRFUUI
{
    public class UIPanel : MonoBehaviour
    {
        public GameObject charaA;
        public GameObject charaB;
        public GameObject bg;
        public GameObject contentTxt;

        public void showCharaA(bool show)
        {
            charaA.SetActive(show);
        }

        public void showCharaB(bool show)
        {
            charaB.SetActive(show);
        }

        public void showContentBG(bool show)
        {
            bg.SetActive(show);
        }

        public void showContentText(bool show)
        {
            contentTxt.SetActive(show);
        }

        public void setContentText(string content)
        {
            contentTxt.GetComponent<Text>().text = content;
        }

        private void Update()
        {
            //Test cases
            if (Input.GetKeyDown("1"))
            {
                showCharaA(true);
            }
            if (Input.GetKeyDown("2"))
            {
                showCharaA(false);
            }
            if (Input.GetKeyDown("3"))
            {
                showContentBG(true);
            }
            if (Input.GetKeyDown("4"))
            {
                showContentBG(false);
            }
            if (Input.GetKeyDown("5"))
            {
                showContentText(true);
            }
            if (Input.GetKeyDown("6"))
            {
                showContentText(false);
            }
        }
    }
}



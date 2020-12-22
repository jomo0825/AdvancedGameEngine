using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MRFUUI
{
    public class UIManager : MonoBehaviour
    {
        public UIPanel panel;

        public void Init()
        {

        }

        public void ShowUI()
        {
            panel.showCharaA(true);
            panel.showContentBG(true);
            panel.showContentText(true);
        }

        public void HideUI()
        {
            panel.showCharaA(false);
            panel.showContentBG(false);
            panel.showContentText(false);
        }

        public void GotoLine(int lineNum)
        {

        }

        public void NextLine() 
        { 
        
        }

        public void LoadText() { 
        
        }

        void Update()
        {
            if (Input.GetKeyDown("z"))
            {
                ShowUI();
            }
            if (Input.GetKeyDown("x"))
            {
                HideUI();
            }
        }

    }
}


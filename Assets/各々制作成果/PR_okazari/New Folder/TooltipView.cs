using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sharkbomb.View
{
    public class TooltipView : MonoBehaviour
    {

        [SerializeField] info sk;

        public bool IsActive
        {
            get
            {
                return gameObject.activeSelf;
            }
        }
        //public CanvasGroup tooltip;
        public UnityEngine.UI.Text tooltipText;
        public UnityEngine.UI.Text tooltipTex;
        public UnityEngine.UI.Text tooltipTe;
        //public UnityEngine.UI.Text tooltipT;

        void Awake()
        {
            instance = this;
            HideTooltip();
        }

        public void ShowTooltip(int skn, Vector2 pos)
        {
            tooltipText.text = sk.skill[skn, 0];
            tooltipTex.text = "消費MP　"+sk.skill[skn, 4];
            if (sk.skill[skn, 1]=="0")
            {
                tooltipTe.text = "技威力"+sk.skill[skn, 2]+"の" + sk.skill[skn, 3] + "回攻撃";

            }
            else tooltipTe.text = sk.setumei[skn];

            transform.localPosition = pos;

            gameObject.SetActive(true);
        }

        public void HideTooltip()
        {
            gameObject.SetActive(false);
        }

        // Standard Singleton Access 
        private static TooltipView instance;
        public static TooltipView Instance
        {
            get
            {
                if (instance == null)
                    instance = GameObject.FindObjectOfType<TooltipView>();
                return instance;
            }
        }
    }
}
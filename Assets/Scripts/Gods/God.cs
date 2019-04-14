using Assets.Scripts.TimeManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Gods
{
    class God : MonoBehaviour
    {
        public Vector3 DefaultPosition;
        public Vector3 ActivePosition;

        private Vector3 TargetPosition;
        private RectTransform RTransform;

        void Start()
        {
            this.TargetPosition = this.DefaultPosition;
            this.RTransform = this.gameObject.GetComponent<RectTransform>();
        }

        void Update()
        {
            this.RTransform.anchoredPosition3D = Vector3.Lerp(this.RTransform.anchoredPosition3D, this.TargetPosition, TimeManager.DeltaTime * 1);
        }


        public void Show()
        {
            this.TargetPosition = this.ActivePosition;
            Invoke("Hide", 4 / TimeManager.Instance.Multiplier);
        }


        public void Hide()
        {
            this.TargetPosition = this.DefaultPosition;
        }

    }
}

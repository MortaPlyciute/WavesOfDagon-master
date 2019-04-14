using Assets.Scripts.Global;
using Assets.Scripts.Points;
using Assets.Scripts.TimeManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    class ButtonManager : MonoBehaviour
    {
        public Button FarmButton;
        public Button BarricadeButton;
        public Button WorkerButton;
        public Button SpeedIncreaseButton;
        public Button SpeedDecreaseButton;


        void Start()
        {
            this.FarmButton.onClick.AddListener(this.FarmButtonClick);
            this.BarricadeButton.onClick.AddListener(this.BarricadeButtonClick);
            this.WorkerButton.onClick.AddListener(this.WorkerButtonClick);

            this.SpeedIncreaseButton.onClick.AddListener(this.SpeedIncreaseButtonClick);
            this.SpeedDecreaseButton.onClick.AddListener(this.SpeedDecreaseButtonClick);
        }

        private void SpeedDecreaseButtonClick()
        {
            TimeManager.Instance.Multiplier *= 0.5f;
        }

        private void SpeedIncreaseButtonClick()
        {
            TimeManager.Instance.Multiplier *= 2f;
        }

        private void WorkerButtonClick()
        {
            if (ReferenceManager.Instance.IsDebugMode || IslandResources.Instance.Resources > 200)
            {
                PrefabManager.Instance.CreateWorker(new Vector3(0, 0.5f, 0), null);
                IslandResources.Instance.Resources -= 200;
            }
        }


        public void FarmButtonClick()
        {
            this.ClearButtonStyles();
            var wasSet = ReferenceManager.Instance.SetBuildingToConstruct(ConstructableBuilding.Farm);
            if (wasSet)
            {
                var color = this.FarmButton.colors;
                color.normalColor = Color.green;
                this.FarmButton.colors = color;
            }
        }


        public void BarricadeButtonClick()
        {
            this.ClearButtonStyles();
            var wasSet = ReferenceManager.Instance.SetBuildingToConstruct(ConstructableBuilding.Barricade);
            if (wasSet)
            {
                var color = this.BarricadeButton.colors;
                color.normalColor = Color.green;
            }
        }


        public void ClearButtonStyles()
        {
            var colors = this.FarmButton.colors;
            colors.normalColor = Color.white;

            colors = this.BarricadeButton.colors;
            colors.normalColor = Color.white;
        }

    }
}

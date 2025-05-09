using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public class HUDController : Observer
    {
        private bool _isTurboOn;
        private float _currentHealth;
        private BikeController _bikeController;

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(50, 50, 100, 200));
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Health: " + _currentHealth);
            GUILayout.EndHorizontal();

            if(_isTurboOn)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Turbo Activate" );
                GUILayout.EndHorizontal();
            }

            if(_currentHealth <= 50f)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Warning! Low health");
                GUILayout.EndHorizontal();
            }

            GUILayout.EndArea();
        }
        public override void Notify(Subject subject)
        {
            if(!_bikeController)
                _bikeController = subject.GetComponent<BikeController>();

            if(_bikeController)
            {
                _isTurboOn = _bikeController.IsTurboOn;
                _currentHealth = _bikeController.CurrentHeath;
            }
        }
    }
}
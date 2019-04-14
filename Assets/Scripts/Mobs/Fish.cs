using Assets.Scripts.TimeManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Mobs
{
    class Fish : MonoBehaviour
    {
        public float _lastJump = 0;
        public float _jumpCooldown = 5;

        private SpriteRenderer _sprite;
        private Animator _anim;

        void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (_lastJump + _jumpCooldown < TimeManager.TimeElapsed)
            {
                this._anim.enabled = true;
                this._sprite.enabled = true;
                _lastJump = TimeManager.TimeElapsed;
                Invoke("DisableAnim", 0.5f);
            }
        }

        void DisableAnim()
        {
            this._anim.enabled = false;
            this._sprite.enabled = false;
        }
    }
}

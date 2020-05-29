using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{

    public class GameManagerScript : MonoBehaviour
    {
        [SerializeField] private float timer;
        public float boostTimer = 25;
        public float oldJumpPower;
        public float newJumpPower = 10;
        public bool hasJumpPower = false;

        [SerializeField] private JumpEnhance jumpEnhance;
        [SerializeField] private FirstPersonController firstPersonController;

    public void Start()
        {
            firstPersonController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
            jumpEnhance = GameObject.Find("TriggerJumpBoost").GetComponent<JumpEnhance>();
            oldJumpPower = firstPersonController.m_JumpSpeed;
        }
        public void Update()
        {
            hasJumpPower = jumpEnhance.jumpPower;
            JumpPowerIncrease();
        }

        public void JumpPowerIncrease()
        {
            
            if (hasJumpPower == true)
            {
                firstPersonController.m_JumpSpeed = newJumpPower;
                Timer();
            }
        }

        public void Timer()
        {
            timer += Time.deltaTime;
            if(timer >= boostTimer)
            {
                jumpEnhance.jumpPower = false;
                firstPersonController.m_JumpSpeed = oldJumpPower;
                timer = 0;
            }
        }
    }
}

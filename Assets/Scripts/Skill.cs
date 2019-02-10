using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player
{
    class Skill
    {
        private bool isLearned;
        private bool isCooldown;
        private bool isPressed;
        private float cooldown;
        private float parameter;

        public bool IsLearned
        {
            get
            {
                return isLearned;
            }

            set
            {
                isLearned = value;
            }
        }

        public bool IsCooldown
        {
            get
            {
                return isCooldown;
            }

            set
            {
                isCooldown = value;
            }
        }

        public bool IsPressed
        {
            get
            {
                return isPressed;
            }

            set
            {
                isPressed = value;
            }
        }

        public float Cooldown
        {
            get
            {
                return cooldown;
            }

            set
            {
                cooldown = value;
            }
        }

        public float Parameter
        {
            get
            {
                return parameter;
            }

            set
            {
                parameter = value;
            }
        }

        public bool CanRunSkill()
        {
            if (IsLearned)
            {
                if (!IsCooldown)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Skills
{
    private Skill jump;
    private Skill dash;
    private Skill flow;

    public Skills()
    {
        Jump = new Skill()
        {
            IsLearned = true,
            IsCooldown = false,
            IsPressed = false,
            Cooldown = 0f,
            Parameter = 700f
        };

        Dash = new Skill()
        {
            IsLearned = true,
            IsCooldown = false,
            IsPressed = false,
            Cooldown = 3f,
            Parameter = 200f
        };

        Flow = new Skill()
        {
            IsLearned = true,
            IsCooldown = false,
            IsPressed = false,
            Cooldown = 5f,
            Parameter = 700f
        };

    }

    public Skill Jump
    {
        get
        {
            return jump;
        }

        set
        {
            jump = value;
        }
    }

    public Skill Dash
    {
        get
        {
            return dash;
        }

        set
        {
            dash = value;
        }
    }

    public Skill Flow
    {
        get
        {
            return flow;
        }

        set
        {
            flow = value;
        }
    }
}

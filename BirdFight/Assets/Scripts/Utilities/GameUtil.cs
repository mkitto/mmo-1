using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class GameUtil
{
    public static bool InScreen(Vector3 position)
    {
        return Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(position));
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Turrt
{
    public class HPBar : MonoBehaviour
    {
        public Image ImageCur;

        public void SetHP(float hp, float maxHp)
        {
            ImageCur.fillAmount = hp / maxHp;
        }
    }
}

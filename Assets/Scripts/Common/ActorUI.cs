using UnityEngine;

namespace Assets.Scripts.Turrt
{
    public class ActorUI: MonoBehaviour
    {
        public HPBar HPBar;
        public HP Actor;

        private void Start()
        {
            Actor.OnHPChanged += OnHPChanged;
        }

        private void OnHPChanged(float hp, float maxHp)
        {
            HPBar.SetHP(hp, maxHp);
        }

        private void OnDestroy()
        {
            Actor.OnHPChanged -= OnHPChanged;
        }
    }
}

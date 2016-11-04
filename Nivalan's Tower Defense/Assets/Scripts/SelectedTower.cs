using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Pertinate
{
    public class SelectedTower : MonoBehaviour
    {
        public Text towerName;
        public Image towerImage;

        public static Tower tower;

        public void SetTower(Tower t)
        {
            tower = t;
        }

        private void Start()
        {
            SetTower(new Tower("test", Tower.TowerType.Wall));
        }
    }
}

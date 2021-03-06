﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MonsterCell : CellBase
    {
        private readonly Player _player = GameManager.Instance.Player;
        private readonly Monster _monster;
        private Tile _tile;

        public MonsterCell(Tile tile)
        {
            _monster = new Monster();
            _tile = tile;
            Type = CellType.Monster;
            GameManager.Instance.Board.Images.Find(pair => pair.CellType.Equals(Type)).Image = _monster.Visual;
        }

        public override void UpdateStatusText()
        {
            _tile.HealthStatusText.text = _monster.Health.Value.ToString();
            _tile.AttackStatusText.text = _monster.Attack.Value.ToString();
            if(_tile.IsOpen)
            {
                _tile.HealthStatusText.gameObject.SetActive(true);
                _tile.AttackStatusText.gameObject.SetActive(true);
            }
        }

        public override void DoAction()
        {
            base.DoAction();
            //Battle
            _monster.Health.RemoveValue(_player.Attack.Value);
            UpdateStatusText();
            _player.Health.RemoveValue(_monster.Attack.Value);
            _player.HealthText.text = _player.Health.Value.ToString();

            if (_player.IsPlayerDead())
            {
                GameManager.Instance.DungeLikeStatisticData.TotalGold += _player.Gold.Value;
                GameManager.Instance.SaveStatisticData();
                MainMenuManager.CanContinue = false;
                //BinarySaver.SaveData(new DungeLikeCurrentGameData());
                SceneManager.LoadScene("EndGame");
            }
        }

        public override bool CanRemoveContent()
        {
            return IsMonsterDead();
        }

        private bool IsMonsterDead()
        {
            bool isMonsterDead = _monster.Health.Value <= _monster.Health.Minimum;
            if (isMonsterDead)
            {
                GameManager.Instance.DungeLikeStatisticData.TotalMonsterKilled++;
                GameManager.Instance.DungeLikeStatisticData.CurrentMonsterKilled++;
            }

            return isMonsterDead;
        }
    }
}

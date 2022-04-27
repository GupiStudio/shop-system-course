using System.Collections.Generic;
using Froggi.Game;
using UnityEngine;

namespace Froggi.Infrastructure
{
	public class Database : MonoBehaviour, IDatabase
	{
		[SerializeField] private DatabaseSO _database;

		private List<ActorData> _actorsData;
		private List<Sprite> _icons;

		public List<ActorData> GetActorsData()
		{
			if (_actorsData != null)
				return _actorsData;

			_actorsData = new List<ActorData>();

			var actors = _database.ActorsData;
			var count = actors.Length;

			for (var i = 0; i < count; i++)
			{
				_actorsData.Add(actors[i]);
			}

			return _actorsData;
		}

		public int GetCoinWorth()
		{
			return _database.CoinWorth.Value;
		}

		public List<Sprite> GetIcons()
		{
			if (_icons != null)
				return _icons;

			_icons = new List<Sprite>();

			var icons = _database.IconPack.Icons;
			var count = icons.Length;

			for (var i = 0; i < count; i++)
			{
				_icons.Add(icons[i]);
			}

			return _icons;
		}
	}
}

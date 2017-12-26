using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace luke21
{
	public class Model
	{
		private enum RelationshipType { Friendship = 0, Enemyship = ~0 };

		private class Relation
		{
			public Relation(RelationshipType relationship, string nameOfPersonA, string nameOfPersonB)
			{
				this.Relationship = relationship;
				this.NameOfPersonA = nameOfPersonA;
				this.NameOfPersonB = nameOfPersonB;
			}

			public RelationshipType Relationship { get; set; }
			public string NameOfPersonA { get; set; }
			public string NameOfPersonB { get; set; }
		}

		private const string Friendship = "vennskap";
		private const string Enemyship = "fiendskap";

		private IEnumerable<Relation> _relations;
		private int _totalPeopleCount;

		public Model(string filename)
		{
			_relations = GetRelations(filename);
			_totalPeopleCount = _relations.Select(r => r.NameOfPersonA)
				.Concat(_relations.Select(r => r.NameOfPersonB))
				.Distinct()
				.Count();
		}

		private void WalkPersonNode(string name, RelationshipType currentFriendsCluster, Dictionary<RelationshipType, HashSet<string>> clusters){
			var allRelations = _relations.Where(r => r.NameOfPersonA == name || r.NameOfPersonB == name);

			foreach (var relation in allRelations)
			{
				var nextPersonToFind = relation.NameOfPersonA != name ? relation.NameOfPersonA : relation.NameOfPersonB;
				if(!clusters.Values.Any(c => c.Contains(nextPersonToFind)))
				{
					if(relation.Relationship == RelationshipType.Friendship)
					{
						clusters[currentFriendsCluster].Add(nextPersonToFind);
					}
					else if(relation.Relationship == RelationshipType.Enemyship)
					{
						clusters[~currentFriendsCluster].Add(nextPersonToFind);
					}

					var nextRelationshipType = relation.Relationship == RelationshipType.Friendship ? currentFriendsCluster : ~currentFriendsCluster;
					WalkPersonNode(nextPersonToFind, nextRelationshipType, clusters);
				}
			}
		}

		public void PrintStatsFor(string name)
		{
			var clusters = new Dictionary<RelationshipType, HashSet<string>>()
			{
				[RelationshipType.Friendship] = new HashSet<string>(),
				[RelationshipType.Enemyship] = new HashSet<string>()
			};
			WalkPersonNode(name, RelationshipType.Friendship, clusters);


			int friendshipCount = clusters[RelationshipType.Friendship].Count();
			int enemyshipCount = clusters[RelationshipType.Enemyship].Count();
			int neutralCount = _totalPeopleCount - (friendshipCount + enemyshipCount);
			Console.WriteLine($"{name} has {friendshipCount} friends and {enemyshipCount} enemies. {neutralCount} are neutral.");
		}

		private IEnumerable<Relation> GetRelations(string filename)
		{
			using (var sr = new StreamReader(filename))
			{
				while (!sr.EndOfStream)
				{
					var parts = sr.ReadLine().Split(" ");
					var relation = parts[0] == Friendship ? RelationshipType.Friendship : RelationshipType.Enemyship;
					yield return new Relation(relation, parts[1], parts[2]);
				}
			}

		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConfig
{
	public class RankStats
	{
		//public string rRank;
		public string rBadge;
		public string rColor;
		public bool rCover;
		public bool rHidden;
		public Dictionary<string, bool> rPerms = new Dictionary<string, bool>();

		/*public RankStats(string rank, string badge, string color, bool cover, bool hidden)
		{
			rRank = rank;
			rBadge = badge;
			rColor = color;
			rCover = cover;
			rHidden = hidden;
		}*/
	}
}

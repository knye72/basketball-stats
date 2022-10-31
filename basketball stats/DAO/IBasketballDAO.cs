using basketball_stats.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace basketball_stats.DAO
{
    public interface IBasketballDAO
    {
        IList<Player> GetPlayer(string playerName);
        void DeletePlayer(int rank);
    }
}

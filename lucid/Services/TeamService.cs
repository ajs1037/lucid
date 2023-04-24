using lucid.Data;
using lucid.Models;

namespace lucid.Services
{
    public class TeamService : Service<Team>, ITeamService
    {
        public TeamService( AppDbContext appDbContext ) : base( appDbContext )
        {

        }
    }
}

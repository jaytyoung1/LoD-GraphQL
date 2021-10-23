using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyTeam.Models;

namespace FantasyTeam.Services
{
    /// <summary>
    /// This creates a way to persist and retrieve the FantasyTeam models.
    /// 
    /// We can register these services to inject them into our GraphQL.NET classes.
    /// 
    /// For sake of the training class, the services are just going to be in memory storage,
    /// but in the real world we'll call out to some external data store/API in order to retrieve and update models.
    /// </summary>
    public class FantasyTeamService : IFantasyTeamService
    {
        // Since the example is just using an in memory colletion
        private IList<Team> _fantasyTeams;

        public FantasyTeamService()
        {
            // Initialize fantasyTeams collection
            _fantasyTeams = new List<Team>();
            _fantasyTeams.Add(new Team(1, "The", "Fournecators", "https://g.espncdn.com/lm-static/logo-packs/ffl/SmackTalk-LeoEspinosa/u_mad_bro-09.svg", new Record(new OverallRecord(0.0, 2, 0.6666666666666666, 652.1, 794.3399999999999, 4, "WIN", 0, 4))));
            _fantasyTeams.Add(new Team(2, "Kareem", "Pies", "https://cdn.profootballrumors.com/files/2018/12/Kareem-Hunt-featuredmm.jpg", new Record(new OverallRecord(0.0, 2, 0.6666666666666666, 687.6, 699.22, 2, "LOSS", 0, 4))));
            _fantasyTeams.Add(new Team(3, "The ", "Bassholes", "https://g.espncdn.com/lm-static/logo-packs/ffl/CreepShow-ToddDetwiler/CreepShow-12.svg", new Record(new OverallRecord(0.0, 2, 0.6666666666666666, 653.1999999999999, 682.3199999999999, 1, "LOSS", 0, 4))));
            _fantasyTeams.Add(new Team(4, "Watch", "What You Saquon", "https://pbs.twimg.com/profile_images/1228503317237633030/_QDW5iID_400x400.jpg", new Record(new OverallRecord(0.0, 2, 0.6666666666666666, 650.24, 669.88, 1, "WIN", 0, 4))));
            _fantasyTeams.Add(new Team(5, "Oh My ", "Godwin", "https://g.espncdn.com/lm-static/logo-packs/ffl/Talent-ChipWass/talent-schefter_2.svg", new Record(new OverallRecord(1.0, 3, 0.5, 670.24, 663.66, 2, "WIN", 0, 3))));
            _fantasyTeams.Add(new Team(6, "Koop", "Kupp Klann", "https://g.espncdn.com/lm-static/ffl/images/default_logos/19.svg", new Record(new OverallRecord(1.0, 3, 0.5, 629.46, 659.1200000000001, 1, "LOSS", 0, 3))));
            _fantasyTeams.Add(new Team(7, "The", "Romosexuals ", "https://g.espncdn.com/lm-static/logo-packs/core/Mascots/mascots-2.svg", new Record(new OverallRecord(2.0, 4, 0.3333333333333333, 728.28, 720.82, 2, "WIN", 0, 2))));
            _fantasyTeams.Add(new Team(8, "Green Bowl", "Packers", "https://g.espncdn.com/lm-static/logo-packs/ffl/CrazyHelmets-ToddDetwiler/Helmets_04.svg", new Record(new OverallRecord(2.0, 4, 0.3333333333333333, 709.22, 660.4, 4, "LOSS", 0, 2))));
            _fantasyTeams.Add(new Team(9, "One-Tit", "Wonders", "https://g.espncdn.com/lm-static/logo-packs/core/StadiumFoods-ESPN/stadium-foods_cupcake.svg", new Record(new OverallRecord(2.0, 4, 0.3333333333333333, 730.22, 635.12, 3, "LOSS", 0, 2))));
            _fantasyTeams.Add(new Team(10, "Fletch Ur", "Cox", "https://g.espncdn.com/lm-static/ffl/images/default_logos/6.svg", new Record(new OverallRecord(2.0, 4, 0.3333333333333333, 698.9999999999999, 624.68, 1, "WIN", 0, 2))));
        }

        public IEnumerable<Team> GetFantasyTeamsRanked()
        {
            // Just call the async version for this example. Return the result of the Task.
            return GetFantasyTeamsRankedAsync().Result;
        }

        public Task<IEnumerable<Team>> GetFantasyTeamsRankedAsync()
        {
            // from example: return Task.FromResult(_fantasyTeams.Single(o => Equals(o.PlayoffSeed)));
            return Task.FromResult(_fantasyTeams.OrderByDescending(team => team.PlayoffSeed).AsEnumerable());
        }

        public IEnumerable<Team> GetPointsAllowed()
        {
            // Just call the async version for this example. Return the result of the Task.
            return GetPointsAllowedAsync().Result;
        }

        public Task<IEnumerable<Team>> GetPointsAllowedAsync()
        {
            return Task.FromResult(_fantasyTeams.OrderByDescending(team => team.Record.Overall.PointsAgainst).AsEnumerable());
        }

        public IEnumerable<Team> GetPointsFor()
        {
            // Just call the async version for this example. Return the result of the Task.
            return GetPointsForAsync().Result;
        }

        public Task<IEnumerable<Team>> GetPointsForAsync()
        {
            return Task.FromResult(_fantasyTeams.OrderByDescending(team => team.Record.Overall.PointsFor).AsEnumerable());
        }
    }

    // Register the FantasyTeamService using the interface.
    // Note: Async calls using Tasks is the best practice for large scale projects.
    // GraphQL.NET will allow us to return Tasks.
    public interface IFantasyTeamService
    {
        // Gets list of fantasy teams ranked.
        IEnumerable<Team> GetFantasyTeamsRanked();
        Task<IEnumerable<Team>> GetFantasyTeamsRankedAsync();

        // Gets fantasy teams sorted by total points for.
        IEnumerable<Team> GetPointsFor();
        Task<IEnumerable<Team>> GetPointsForAsync();

        // Gets fantasy teams sorted by total points allowed.
        IEnumerable<Team> GetPointsAllowed();
        Task<IEnumerable<Team>> GetPointsAllowedAsync();
    }
}


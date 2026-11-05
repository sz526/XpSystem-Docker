namespace XpSystem;

public class FakePlayerRepository : IPlayerRepository // In-memory-repository, kun for unit-tester (ingen database, ingen EF Core).
{
    private readonly List<PlayerModel> _players = new();

    public PlayerModel Add(PlayerModel player)
    {
        _players.Add(player);
        return player;
    }

    public PlayerModel? GetById(int id)
        => _players.FirstOrDefault(p => p.Id == id);

    public List<PlayerModel> GetAll()
        => _players.ToList();
}

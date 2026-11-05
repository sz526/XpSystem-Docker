namespace XpSystem;

public class PlayerService
{
    private readonly List<PlayerModel> _players = new();
    private int _nextId = 1;

    public PlayerModel CreatePlayer(string name)
    {
        var player = new PlayerModel { Id = _nextId++, Name = name };
        _players.Add(player);
        return player;
    }
}

/* namespace XpSystem;

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

    public void GainXp(int id, int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "XP amount cannot be negative.");
        }
        
        var player = _players.First(p => p.Id == id);
        player.Xp += amount;

        while (player.Xp >= 100) // If the player's XP reaches or exceeds 100, level up and reset XP.
        // using `while` instead of `if` is that `GainXp(id, 250)` might need to advance two levels at once—and 
        
        {
            player.Xp -= 100;
            player.Level++;
        }
    }
    public List<PlayerModel> GetAllPlayers()
    {
        return _players.ToList();
    }

}
 */

 namespace XpSystem;

public class PlayerService
{
    private readonly IPlayerRepository _repository;
    private int _nextId = 1;

    public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public PlayerModel CreatePlayer(string name)
    {
        var player = new PlayerModel { Id = _nextId++, Name = name };
        return _repository.Add(player);
    }

    public List<PlayerModel> GetAllPlayers()
        => _repository.GetAll();

    public void GainXp(int id, int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "amount kan ikke være negativ");
        }

        var player = _repository.GetById(id) ?? throw new InvalidOperationException("Spiller ikke funnet");
        player.Xp += amount;

        while (player.Xp >= 100)
        {
            player.Xp -= 100;
            player.Level++;
        }
    }
}

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

    public void GainXp(int id, int amount)
    {
        var player = _players.First(p => p.Id == id);
        player.Xp += amount;

        while (player.Xp >= 100) // If the player's XP reaches or exceeds 100, level up and reset XP.
        // using `while` instead of `if` is that `GainXp(id, 250)` might need to advance two levels at once—and 
        
        {
            player.Xp -= 100;
            player.Level++;
        }
    }

}

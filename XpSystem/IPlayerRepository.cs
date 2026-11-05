namespace XpSystem;

public interface IPlayerRepository // Interface for player repository, defining methods for adding, retrieving, and listing players.
{
    PlayerModel Add(PlayerModel player);
    PlayerModel? GetById(int id);
    List<PlayerModel> GetAll();
}

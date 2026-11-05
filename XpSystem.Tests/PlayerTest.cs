using XpSystem;

namespace XpSystem.Tests;

public class PlayerTests
{
    [Fact]
    public void CreatePlayer_ShouldInitializeWithUniqueIdLevelOneAndZeroXp()
    {
        //var service = new PlayerService();
        var repository = new FakePlayerRepository();
        var service = new PlayerService(repository);

        var player1 = service.CreatePlayer("Hero");
        var player2 = service.CreatePlayer("Mage");

        Assert.Equal(1, player1.Id);
        Assert.Equal(2, player2.Id);
        Assert.Equal(1, player1.Level);
        Assert.Equal(0, player1.Xp);
    }
    [Fact]
    public void GainXp_SpecificPlayerId_ShouldIncreaseXpAndLevelUp()
    {
        // Arrange
        var repository = new FakePlayerRepository();
        var service = new PlayerService(repository);
        var player = service.CreatePlayer("Hero");
        // Act
        service.GainXp(player.Id, 40);
        Assert.Equal(40, player.Xp);

        // assert that the player levels up correctly when XP reaches 100
        service.GainXp(player.Id, 60); // total 100
        Assert.Equal(2, player.Level);
        Assert.Equal(0, player.Xp);
    }

    [Fact]
    public void GetAllPlayers_ShouldReturnAllStoredPlayers()
    {
        var repository = new FakePlayerRepository();
        var service = new PlayerService(repository);
        service.CreatePlayer("Hero");
        service.CreatePlayer("Mage");

        var allPlayers = service.GetAllPlayers();

        Assert.Equal(2, allPlayers.Count);
    }
    [Fact]
    public void GainXp_NegativeAmount_ShouldThrowArgumentOutOfRangeException()
    {
        var repository = new FakePlayerRepository();
        var service = new PlayerService(repository);
        var player = service.CreatePlayer("Hero");

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            service.GainXp(player.Id, -50));

        Assert.Contains("amount", exception.Message);
    }


}

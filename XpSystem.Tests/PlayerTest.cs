using XpSystem;

namespace XpSystem.Tests;

public class PlayerTests
{
    [Fact]
    public void CreatePlayer_ShouldInitializeWithUniqueIdLevelOneAndZeroXp()
    {
        var service = new PlayerService();

        var player1 = service.CreatePlayer("Hero");
        var player2 = service.CreatePlayer("Mage");

        Assert.Equal(1, player1.Id);
        Assert.Equal(2, player2.Id);
        Assert.Equal(1, player1.Level);
        Assert.Equal(0, player1.Xp);
    }
}

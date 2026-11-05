# XpSystem — Oppgave 1 (TDD)

A small XP / player system built **from scratch with Test-Driven Development** for the
C# Advanced course (Kodehode Vestfold/Telemark).

## What it does

`PlayerService` manages players:

- create a player with a unique, auto-incremented id — starts at **level 1, 0 XP**
- gain XP; every **100 XP** raises the level and resets XP to 0
- list all players
- reject a negative XP amount with `ArgumentOutOfRangeException`

## Architecture

One solution, two projects:

```
XpSystem-TDD/                  solution (XpSystem-TDD.sln / .slnx)
├── XpSystem/                  class library — domain + business logic
│   ├── PlayerModel.cs             entity: Id, Name, Level, Xp
│   ├── IPlayerRepository.cs       storage contract (abstraction)
│   ├── FakePlayerRepository.cs    in-memory implementation (used by tests)
│   └── PlayerService.cs           business logic, depends on IPlayerRepository
└── XpSystem.Tests/            xUnit test project
    └── PlayerTests.cs             4 behaviour tests
```

`PlayerService` depends on the **`IPlayerRepository` interface**, not on a concrete
storage class (dependency inversion). The storage implementation can therefore be
swapped without touching the business logic — which is exactly what is reused in
assignment 2, where an EF Core repository replaces the fake one.

## Test-Driven Development

Every behaviour was added in the classic three-step cycle, one commit per step:

| Step | Commit prefix | What happens |
|---|---|---|
| **RED** | `RED: ...` | Write a failing test (it is red) |
| **GREEN** | `GREEN: ...` | Write the minimal code that makes it pass |
| **REFACTOR** | `REFACTOR: ...` | Improve the structure without changing behaviour |

Commit history:

```
INIT      solution + XpSystem + XpSystem.Tests
RED       CreatePlayer: unique id, level 1, xp 0
GREEN     implement CreatePlayer
RED       GainXp: gain xp and level up at 100
GREEN     implement GainXp with level-up
RED       GetAllPlayers: return all players
GREEN     implement GetAllPlayers
RED       GainXp: negative amount throws
GREEN     validate negative amount
REFACTOR  PlayerService depends on IPlayerRepository
```

## Tests

| Test | Verifies |
|---|---|
| `CreatePlayer_ShouldInitializeWithUniqueIdLevelOneAndZeroXp` | unique id, level 1, xp 0 |
| `GainXp_SpecificPlayerId_ShouldIncreaseXpAndLevelUp` | xp increases, level up at 100 |
| `GetAllPlayers_ShouldReturnAllStoredPlayers` | returns every stored player |
| `GainXp_NegativeAmount_ShouldThrowArgumentOutOfRangeException` | negative input is rejected |

## Run

```bash
dotnet build
dotnet test
```

Requires the .NET 10 SDK. Tests use xUnit.

## Stack

- C# / .NET 10
- xUnit
- Interfaces + constructor injection (dependency inversion)

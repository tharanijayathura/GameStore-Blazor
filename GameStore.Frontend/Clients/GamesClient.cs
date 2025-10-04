using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games =
   [
   new(){
        Id=1,
        Name="Street Fighter II",
        Genre="Fighting",
        Price=19.99M,
        ReleaseDate=new DateOnly(2017,3,3)
    },
    new(){
        Id=2,
        Name="The Zelda",
        Genre="Adventure",
        Price=29.99M,
        ReleaseDate=new DateOnly(1998,11,21)
    },
    new(){
        Id=3,
        Name="Minecraft",
        Genre="Sandbox",
        Price=26.95M,
        ReleaseDate=new DateOnly(2011,11,18)
    }

   ];
    public GameSummary[] GetGames() => [.. games];

}

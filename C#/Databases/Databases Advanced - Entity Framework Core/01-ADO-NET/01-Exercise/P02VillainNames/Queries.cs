﻿namespace P02VillainNames
{
    public static class Queries
    {
        public static string VillainNames =
                                    @"  SELECT v.[Name], COUNT(mv.VillainId) AS MinionsCount  
                                           FROM Villains AS v 
                                           JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                       GROUP BY v.[Id], v.[Name] 
                                         HAVING COUNT(mv.VillainId) > 3 
                                       ORDER BY COUNT(mv.VillainId)";
    }
}

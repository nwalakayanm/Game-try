using System;
using System.Collections.Generic;

namespace EchoArchitect.Core
{
    // Define the base elements and traits
    public enum ElementType { Base, Mineral, Toxic, Pure, Bioluminescent }
    public enum Rarity { Common, Uncommon, Rare, Epic, Legendary }

    public class TerrainTile
    {
        public int X, Y;
        public bool IsHydrated;
        public WaterSource ActiveWater;
        public Plant Occupant;
    }

    public class WaterSource
    {
        public string OwnerID; // e.g., "Nova_Kyoto"
        public ElementType Modifier; // e.g., ElementType.Mineral
    }

    public class Plant
    {
        public string Name;
        public string DiscoveredBy;
        public Rarity Tier;
        public string PassiveEffect;
    }

    public class CrossPollinationEngine
    {
        // A dictionary acting as our "Recipe Book" for genetic combinations
        private Dictionary<(ElementType, ElementType), PlantData> GeneticDatabase;

        public CrossPollinationEngine()
        {
            InitializeGenetics();
        }

        private void InitializeGenetics()
        {
            // Seed the database with potential combinations
            GeneticDatabase = new Dictionary<(ElementType, ElementType), PlantData>
            {
                { (ElementType.Base, ElementType.Mineral), new PlantData("Azure-Lung Fern", Rarity.Epic, "Cleans atmospheric toxicity in a 50-tile radius.") },
                { (ElementType.Base, ElementType.Toxic), new PlantData("Slag-Weed", Rarity.Common, "Absorbs ground radiation but slows nearby growth.") },
                { (ElementType.Bioluminescent, ElementType.Pure), new PlantData("Lantern Lotus", Rarity.Rare, "Provides light and speeds up nocturnal insect spawning.") }
            };
        }

        /// <summary>
        /// Attempts to plant a seed on a specific tile and calculates mutations based on neighbors.
        /// </summary>
        public Plant PlantSeed(TerrainTile targetTile, ElementType seedType, string playerID)
        {
            if (!targetTile.IsHydrated || targetTile.ActiveWater == null)
            {
                Console.WriteLine("System: Seed failed to germinate. Requires hydration.");
                return null;
            }

            ElementType waterType = targetTile.ActiveWater.Modifier;
            string waterOwner = targetTile.ActiveWater.OwnerID;

            // Check if this specific combination of Seed + Water exists in our genetics database
            if (GeneticDatabase.TryGetValue((seedType, waterType), out PlantData resultData))
            {
                Plant newSpecies = new Plant
                {
                    Name = resultData.Name,
                    Tier = resultData.Tier,
                    PassiveEffect = resultData.Effect,
                    // Logs both players for the asynchronous social feature!
                    DiscoveredBy = $"{playerID} & {waterOwner}" 
                };

                targetTile.Occupant = newSpecies;
                TriggerDiscoveryEvent(newSpecies);
                
                return newSpecies;
            }

            // Default fallback plant if no special mutation occurs
            return new Plant { Name = "Basic Sprout", Tier = Rarity.Common, DiscoveredBy = playerID };
        }

        private void TriggerDiscoveryEvent(Plant discoveredPlant)
        {
            // In a real game, this would ping the server and UI
            Console.WriteLine("\n--- NEW DISCOVERY! ---");
            Console.WriteLine($"Species Formed: {discoveredPlant.Name}");
            Console.WriteLine($"Discovered By: {discoveredPlant.DiscoveredBy}");
            Console.WriteLine($"Global Rarity: {discoveredPlant.Tier}");
            Console.WriteLine($"Passive Effect: {discoveredPlant.PassiveEffect}");
            Console.WriteLine("----------------------\n");
        }

        // Helper struct for database
        private struct PlantData
        {
            public string Name;
            public Rarity Tier;
            public string Effect;

            public PlantData(string name, Rarity tier, string effect)
            {
                Name = name; Tier = tier; Effect = effect;
            }
        }
    }
}

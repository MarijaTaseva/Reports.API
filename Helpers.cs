using System;
using System.Collections.Generic;

namespace RiaRu.API
{
    public class Helpers
    {
        private static Random _rand = new Random();
        private static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }
        internal static string MakeUniqueCustomerName(List<string> names)
        {
            var maxNames = bizPrefix.Count*bizSuffix.Count;

            if(names.Count >= maxNames)
            {
                throw new System.InvalidOperationException("Maximum number of unique names exceeded");
            }
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);
            var bizName = prefix + suffix;

            if(names.Contains(bizName))
            {
                MakeUniqueCustomerName(names);
            }

            return bizName;
        }

        internal static string MakeCustomerEmail(string customerName)
        {
            return $"contact@{customerName.ToLower()}.com";
        }

        internal static string GetRandomState()
        {
            return GetRandom(usStates);
        }

        internal static decimal GetRandomOrderTotal()
        {
            return _rand.Next(100,5000);
        }

        internal static DateTime GetRandomOrderPlaced()
        {
            var end = DateTime.Now;
            var start = end.AddDays(-90);

            TimeSpan possibleSpan = end - start;
            TimeSpan newSpan = new TimeSpan(0, _rand.Next(0, (int)possibleSpan.TotalMinutes), 0);

            return start + newSpan;
        }

        internal static DateTime? GetRandomOrderCompleted(DateTime orderPlaced)
        {
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var timePassed = now - orderPlaced;

            if(timePassed < minLeadTime)
            {
                return null;
            }

            return orderPlaced.AddDays(_rand.Next(7,14));
        }

        private static readonly List<string> usStates = new List<string>()
        {
            "AK","AL","LK","KS","DF","ALS"
        };
        private static readonly List<string> bizPrefix = new List<string>()
        {
            "ANC",
            "DASD",
            "MainSt",
            "dsadd",
            "drewrewh fds",
            "dasdasd",
            "dasdstyry",
            "dsatert"
        };
        private static readonly List<string> bizSuffix = new List<string>()
        {
            "trhgh",
            "DASdsadasD",
            "MadsabginSt",
            "dsadjhkd",
            "drewreeeeewh fds",
            "das",
            "e",
            "trgfg"
        };
    }
}
﻿//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.HpService
{
    public class HpService : IHpService
    {
        private readonly long[,] _hpData = new long[5, Constants.MaxLevel];
        public readonly int[][] ClassConstants = new int[][] { new int[] { 0, 0, 0 }, new int[] { 8, 2, 0 }, new int[] { 3, 6, 1 }, new int[] { 0, 2, 8 }, new int[] { 5, 3, 2 } };

        public HpService()
        {
            foreach (CharacterClassType classType in Enum.GetValues(typeof(CharacterClassType)))
            {
                for (var i = 0; i < Constants.MaxLevel; i++)
                {
                    var hpx = i + 1 + Math.Floor(i * (double)(ClassConstants[(int)classType][0]) / 10);
                    var hp = (0.5 * Math.Pow(hpx, 2)) + (15.5 * hpx) + 205;
                    _hpData[(int)classType, i] = (long)hp;
                }
            }
        }
        public long GetHp(CharacterClassType @class, byte level)
        {
            return _hpData![(byte)@class, level-1];
        }
    }
}

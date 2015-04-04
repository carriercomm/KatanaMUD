﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using KatanaMUD.Models;

namespace KatanaMUD.Importer.Structures
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public struct RaceBuffer
	{
		short Number;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 29)]
		char[] Name;
		byte nothing1;
		short MinInt;
		short MinWil;
		short MinStr;
		short MinHea;
		short MinAgl;
		short MinChm;
		short HPBonus;
		int nothing2;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
		short[] AbilityA;
		short CP;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
		short[] AbilityB;
		int nothing3;
		short nothing4;
		short ExpChart;
		short nothing5;
		short MaxInt;
		short MaxWil;
		short MaxStr;
		short MaxHea;
		short MaxAgl;
		short MaxChm;
		int Nothing6;
		int nothing7;
		int nothing8;

		public RaceTemplate ToRace()
		{
			return new RaceTemplate()
			{
				Id = Number,
				Name = new string(Name).Replace("\0", "").Trim(),
				Strength = MinStr,
				Agility = MinAgl,
				Health = MinHea,
				Intelligence = MinInt,
				Wisdom = MinWil,
				Charm = MinChm,
				StrengthCap = MaxStr,
				AgilityCap = MaxAgl,
				HealthCap = MaxHea,
				IntelligenceCap = MaxInt,
				WisdomCap = MaxWil,
				CharmCap = MaxChm,
				Hp = HPBonus
			};
        }
	}
}
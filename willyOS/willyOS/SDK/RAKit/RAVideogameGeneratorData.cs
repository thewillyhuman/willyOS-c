using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace willyOS {
	/// <summary>
	/// A class with information of videogames of the PS3, XBox360 and Wii games.
	/// </summary>
	public class RAVideogameGeneratorData {
		/// <summary>
		/// Header of the videogame data, to interpret its information
		/// </summary>
		public static string[] header =
		{
			"Game", "Platform", "Year", "Genre", "Publisher", "North America", "Europe",
			"Japan", "Rest of World"
		};

		/// <summary>
		/// PS3 game information.
		/// </summary>
		public static string[,] Ps3Games =
		{
			{"Grand Theft Auto V", "PS3", "2013", "Action", "Take-Two Interactive", "6.25", "8.02", "0.85", "3.93"},
			{"Call of Duty: Black Ops II", "PS3", "2012", "Shooter", "Activision", "4.77", "5.41", "0.57", "2.45"},
			{"Call of Duty: Modern Warfare 3", "PS3", "2011", "Shooter", "Activision", "5.42", "5.60", "0.49", "1.59"},
			{"Call of Duty: Black Ops", "PS3", "2010", "Shooter", "Activision", "5.83", "4.26", "0.48", "1.80"},
			{"Gran Turismo 5", "PS3", "2010", "Racing", "Sony Computer Entertainment", "2.86", "4.74", "0.81", "2.11"},
			{"Call of Duty: Modern Warfare 2", "PS3", "2009", "Shooter", "Activision", "4.93", "3.57", "0.38", "1.61"},
			{"Grand Theft Auto IV", "PS3", "2008", "Action", "Take-Two Interactive", "4.65", "3.61", "0.44", "1.58"},
			{"Call of Duty: Ghosts", "PS3", "2013", "Shooter", "Activision", "3.58", "3.38", "0.38", "2.02"},
			{"FIFA Soccer 13", "PS3", "2012", "Action", "Electronic Arts", "1.03", "4.94", "0.13", "2.01"},
			{"Battlefield 3", "PS3", "2011", "Shooter", "Electronic Arts", "2.77", "2.83", "0.35", "1.09"},
			{"FIFA Soccer 14", "PS3", "2013", "Sports", "Electronic Arts", "0.70", "4.04", "0.07", "2.00"},
			{"FIFA Soccer 12", "PS3", "2011", "Sports", "Electronic Arts", "0.81", "4.27", "0.11", "1.41"},
			{
				"Uncharted 3: Drake's Deception", "PS3", "2011", "Action", "Sony Computer Entertainment", "2.67", "2.66",
				"0.19", "1.06"
			},
			{"Call of Duty 4: Modern Warfare", "PS3", "2007", "Shooter", "Activision", "3.02", "2.22", "0.28", "1.01"},
			{
				"Uncharted 2: Among Thieves", "PS3", "2009", "Action", "Sony Computer Entertainment", "3.19", "2.13",
				"0.21", "0.98"
			},
			{"Red Dead Redemption", "PS3", "2010", "Action", "Take-Two Interactive", "2.65", "2.41", "0.17", "1.00"},
			{"Assassin's Creed III", "PS3", "2012", "Action", "Ubisoft", "2.47", "2.42", "0.16", "1.12"},
			{
				"Metal Gear Solid 4: Guns of the Patriots", "PS3", "2008", "Action", "Konami Digital Entertainment", "2.60",
				"1.68", "0.83", "0.82"
			},
			{
				"The Elder Scrolls V: Skyrim", "PS3", "2011", "Role-Playing", "Bethesda Softworks", "2.25", "2.43", "0.25",
				"0.98"
			}
		};

		/// <summary>
		/// XBox360 game information
		/// </summary>
		public static string[,] XBox360Games =
		{
			{"Kinect Adventures!", "X360", "2010", "Misc", "Microsoft Game Studios", "14.63", "4.82", "0.24", "1.62"},
			{"Grand Theft Auto V", "X360", "2013", "Action", "Take-Two Interactive", "8.56", "4.81", "0.06", "1.21"},
			{"Call of Duty: Modern Warfare 3", "X360", "2011", "Shooter", "Activision", "8.81", "4.16", "0.13", "1.29"},
			{"Call of Duty: Black Ops", "X360", "2010", "Shooter", "Activision", "9.37", "3.60", "0.11", "1.08"},
			{"Call of Duty: Modern Warfare 2", "X360", "2009", "Shooter", "Activision", "8.42", "3.54", "0.08", "1.27"},
			{"Call of Duty: Black Ops II", "X360", "2012", "Shooter", "Activision", "7.92", "4.11", "0.06", "1.07"},
			{"Halo 3", "X360", "2007", "Shooter", "Microsoft Game Studios", "7.85", "2.80", "0.13", "1.19"},
			{"Grand Theft Auto IV", "X360", "2008", "Action", "Take-Two Interactive", "6.61", "3.05", "0.14", "1.00"},
			{"Halo: Reach", "X360", "2010", "Shooter", "Microsoft Game Studios", "6.90", "1.91", "0.08", "0.76"},
			{"Halo 4", "X360", "2012", "Shooter", "Microsoft Game Studios", "6.37", "2.17", "0.04", "0.69"},
			{"Call of Duty: Ghosts", "X360", "2013", "Shooter", "Activision", "6.07", "2.40", "0.04", "0.71"},
			{"Call of Duty 4: Modern Warfare", "X360", "2007", "Shooter", "Activision", "5.79", "2.33", "0.13", "0.88"},
			{
				"The Elder Scrolls V: Skyrim", "X360", "2011", "Role-Playing", "Bethesda Softworks", "4.63", "2.68", "0.10",
				"0.79"
			},
			{"Battlefield 3", "X360", "2011", "Shooter", "Electronic Arts", "4.38", "2.09", "0.06", "0.68"},
			{"Call of Duty: World at War", "X360", "2008", "Shooter", "Activision", "4.64", "1.84", "0.00", "0.67"},
			{"Gears of War 2", "X360", "2008", "Shooter", "Microsoft Game Studios", "4.11", "1.90", "0.06", "0.63"},
			{"Halo 3: ODST", "X360", "2009", "Shooter", "Microsoft Game Studios", "4.28", "1.33", "0.06", "0.60"},
			{"MineCraft", "X360", "2013", "Adventure", "Microsoft Game Studios", "3.83", "1.87", "0.02", "0.50"},
			{"Gears of War 3", "X360", "2011", "Shooter", "Microsoft Game Studios", "3.98", "1.56", "0.07", "0.48"},
			{"Red Dead Redemption", "X360", "2010", "Action", "Take-Two Interactive", "3.56", "1.88", "0.09", "0.55"},
			{"Gears of War", "X360", "2006", "Shooter", "Microsoft Game Studios", "3.52", "1.87", "0.07", "0.60"},
			{"Kinect Sports", "X360", "2010", "Sports", "Microsoft Game Studios", "3.77", "1.66", "0.03", "0.48"},
			{"Assassin's Creed", "X360", "2007", "Adventure", "Ubisoft", "3.21", "1.64", "0.07", "0.55"},
			{"Forza Motorsport 3", "X360", "2009", "Racing", "Microsoft Game Studios", "2.96", "1.88", "0.10", "0.50"},
			{"Assassin's Creed II", "X360", "2009", "Action", "Ubisoft", "3.03", "1.53", "0.08", "0.50"},
			{"FIFA Soccer 13", "X360", "2012", "Action", "Electronic Arts", "1.04", "3.46", "0.03", "0.58"},
			{"Assassin's Creed III", "X360", "2012", "Action", "Ubisoft", "2.93", "1.65", "0.03", "0.42"},
			{"Fable III", "X360", "2010", "Role-Playing", "Microsoft Game Studios", "3.52", "1.06", "0.05", "0.37"},
			{"Guitar Hero III: Legends of Rock", "X360", "2007", "Misc", "Activision", "3.15", "0.91", "0.01", "0.41"},
			{
				"Batman: Arkham City", "X360", "2011", "Action", "Warner Bros. Interactive Entertainment", "2.81", "1.23",
				"0.04", "0.39"
			}
		};

		/// <summary>
		/// Wii game information
		/// </summary>
		public static string[,] WiiGames =
		{
			{"Wii Sports", "Wii", "2006", "Sports", "Nintendo", "41.24", "28.83", "3.77", "8.42"},
			{"Mario Kart Wii", "Wii", "2008", "Racing", "Nintendo", "15.34", "12.53", "3.75", "3.22"},
			{"Wii Sports Resort", "Wii", "2009", "Sports", "Nintendo", "15.51", "10.82", "3.26", "2.92"},
			{"Wii Play", "Wii", "2006", "Misc", "Nintendo", "13.93", "9.16", "2.93", "2.84"},
			{"New Super Mario Bros. Wii", "Wii", "2009", "Platform", "Nintendo", "14.10", "6.72", "4.69", "2.18"},
			{"Wii Fit", "Wii", "2007", "Sports", "Nintendo", "8.92", "8.03", "3.60", "2.14"},
			{"Wii Fit Plus", "Wii", "2009", "Sports", "Nintendo", "8.96", "8.35", "2.53", "1.76"},
			{"Super Smash Bros. Brawl", "Wii", "2008", "Fighting", "Nintendo", "6.38", "2.42", "2.62", "0.96"},
			{"Super Mario Galaxy", "Wii", "2007", "Platform", "Nintendo", "5.97", "3.27", "1.20", "0.72"},
			{"Just Dance 3", "Wii", "2011", "Misc", "Ubisoft", "5.88", "3.09", "0.00", "1.04"},
			{"Just Dance 2", "Wii", "2010", "Misc", "Ubisoft", "5.78", "2.83", "0.01", "0.77"},
			{"Wii Party", "Wii", "2010", "Misc", "Nintendo", "1.73", "3.38", "2.48", "0.67"},
			{"Mario Party 8", "Wii", "2007", "Misc", "Nintendo", "3.72", "2.14", "1.58", "0.71"},
			{"Mario & Sonic at the Olympic Games", "Wii", "2007", "Sports", "Sega", "2.56", "3.83", "0.66", "0.91"},
			{"Super Mario Galaxy 2", "Wii", "2010", "Platform", "Nintendo", "3.49", "2.23", "0.98", "0.61"},
			{"Just Dance", "Wii", "2009", "Misc", "Ubisoft", "3.46", "2.95", "0.00", "0.72"},
			{
				"The Legend of Zelda: Twilight Princess", "Wii", "2006", "Action", "Nintendo", "3.69", "2.06", "0.60",
				"0.67"
			},
			{"Just Dance 4", "Wii", "2012", "Misc", "Ubisoft", "4.01", "2.10", "0.00", "0.54"},
			{"Zumba Fitness", "Wii", "2010", "Sports", "505 Games", "3.42", "2.54", "0.00", "0.66"},
			{"Donkey Kong Country Returns", "Wii", "2010", "Platform", "Nintendo", "3.10", "1.69", "1.03", "0.45"},
			{"LEGO Star Wars: The Complete Saga", "Wii", "2007", "Action", "LucasArts", "3.47", "1.46", "0.00", "0.49"},
			{"Link's Crossbow Training", "Wii", "2007", "Shooter", "Nintendo", "3.04", "1.16", "0.29", "0.46"},
			{"Guitar Hero III: Legends of Rock", "Wii", "2007", "Misc", "Activision", "3.03", "1.11", "0.00", "0.43"},
			{"Animal Crossing: City Folk", "Wii", "2008", "Simulation", "Nintendo", "1.80", "1.10", "1.32", "0.36"},
			{
				"Mario & Sonic at the Olympic Winter Games", "Wii", "2009", "Sports", "Sega", "1.86", "1.92", "0.22",
				"0.48"
			},
			{"Michael Jackson: The Experience", "Wii", "2010", "Misc", "Ubisoft", "2.62", "1.30", "0.01", "0.38"},
			{"Carnival Games", "Wii", "2007", "Misc", "Take-Two Interactive", "2.11", "1.45", "0.05", "0.41"},
			{"EA Sports Active", "Wii", "2009", "Sports", "Electronic Arts", "2.08", "1.35", "0.06", "0.40"},
			{"The Legend of Zelda: Skyward Sword", "Wii", "2011", "Action", "Nintendo", "1.96", "1.11", "0.37", "0.37"},
			{"Big Brain Academy: Wii Degree", "Wii", "2007", "Misc", "Nintendo", "1.04", "1.90", "0.41", "0.42"},
			{"Super Paper Mario", "Wii", "2007", "Platform", "Nintendo", "1.94", "0.83", "0.59", "0.31"},
			{
				"Mario & Sonic at the London 2012 Olympic Games", "Wii", "2011", "Sports", "Sega", "1.11", "1.82", "0.27",
				"0.45"
			}
		};
	}
}
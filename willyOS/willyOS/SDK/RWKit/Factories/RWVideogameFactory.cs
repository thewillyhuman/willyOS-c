using System;
using System.Collections.Generic;
using RAKit;

namespace RWKit {

	/// <summary>
	/// RWV ideogame factory.
	/// </summary>
	public static class RWVideogameFactory {

		/// <summary>
		/// This method creates the specified number of videogames, using random data from the videogame list also provided
		/// </summary>
		/// <param name="numberOfVideogames">Number of videogames to be created</param>
		/// <returns>An array of Videogame instances, fully instantiated from the videogame data</returns>
		public static RWVideogame[] CreateRandomVideoGames(int numberOfVideogames = 100) {
			RWVideogame[] listing = new RWVideogame[numberOfVideogames];
			Random random = new Random();
			string[,] data = null;
			VidegamePlatform platform = VidegamePlatform.PS3;

			for (int i = 0; i < numberOfVideogames; i++) {
				int platformNumber = random.Next(0, 3);
				if (platformNumber == 0) {
					data = RAVideogameGeneratorData.Ps3Games;
					platform = VidegamePlatform.PS3;
				}

				if (platformNumber == 1) {
					data = RAVideogameGeneratorData.XBox360Games;
					platform = VidegamePlatform.Xbox360;
				}

				if (platformNumber == 2) {
					data = RAVideogameGeneratorData.WiiGames;
					platform = VidegamePlatform.Wii;
				}

				int gameNumber = random.Next(0, data.GetLength(0));

				int year = 2020;
				try {
					year = int.Parse(data[gameNumber, 2]);
				} catch (Exception e) { };
				listing[i] = new RWVideogame {
					Title = data[gameNumber, 0],
					Platform = platform,
					Year = year,
					Genre = data[gameNumber, 3],
					Editor = data[gameNumber, 4],
					AmericaSales = double.Parse(data[gameNumber, 5].Replace(".", ",")),
					EuropeSales = double.Parse(data[gameNumber, 6].Replace(".", ",")),
					JapanSales = double.Parse(data[gameNumber, 7].Replace(".", ",")),
					RestOfTheWorldSales = double.Parse(data[gameNumber, 8].Replace(".", ",")),
					AvailableUnits = random.Next(10, 100),
				};
			}
			return listing;
		}

		/// <summary>
		/// Helper method to parse the videogame library of a specified platform
		/// </summary>
		/// <param name="data">Videogame data</param>
		/// <param name="platform">Destination platform (all videogames will belong to it</param>
		/// <param name="output">List to fill with the processed videogames</param>
		private static void ParseVideogameLibrary(string[,] data, VidegamePlatform platform, List<RWVideogame> output) {
			Random random = new Random();

			for (int i = 0; i < data.GetLength(0); i++) {
				int year = 2020;
				try {
					year = int.Parse(data[i, 2]);
				} catch (Exception) {
					//A non-valid year means that year = 2020
				}
				output.Add(new RWVideogame {
					Title = data[i, 0],
					Platform = platform,
					Year = year,
					Genre = data[i, 3],
					Editor = data[i, 4],
					AmericaSales = double.Parse(data[i, 5].Replace(".", ",")),
					EuropeSales = double.Parse(data[i, 6].Replace(".", ",")),
					JapanSales = double.Parse(data[i, 7].Replace(".", ",")),
					RestOfTheWorldSales = double.Parse(data[i, 8].Replace(".", ",")),
					AvailableUnits = random.Next(10, 100),
				});
			}
		}

		/// <summary>
		/// Processes the entire videogame data lists and return it in a Videogame array.
		/// </summary>
		/// <returns>An array of videogames</returns>
		public static RWVideogame[] CreateFullVideoGameLibrary() {
			List<RWVideogame> listing = new List<RWVideogame>();

			VidegamePlatform platform = VidegamePlatform.PS3;
			ParseVideogameLibrary(RAVideogameGeneratorData.Ps3Games, platform, listing);

			platform = VidegamePlatform.Xbox360;
			ParseVideogameLibrary(RAVideogameGeneratorData.XBox360Games, platform, listing);

			platform = VidegamePlatform.Wii;
			ParseVideogameLibrary(RAVideogameGeneratorData.WiiGames, platform, listing);

			return listing.ToArray();
		}
	}
}

using SportsGlobe.Web.Domain;

namespace SportsGlobe.Web.Application
{
    public class CoordinatesService
    {
        /// <summary>
        /// Parses string that is formatted like latitude,longitude
        /// to Coordinate class which contains double properties for both.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Coordinate ParseFromString(string input)
        {
            Coordinate coordinate = new Coordinate();

            double latitude = 0;
            double longitude = 0;

            var extracted = input.Trim().Split(",");
            if (extracted.Length == 2)
            {
                // trim strings and then try to parse them //
                if (!double.TryParse(extracted[0].Trim(), out latitude))
                {
                    throw new Exception("The input could not be parsed.");
                }
                if (!double.TryParse(extracted[1].Trim(), out longitude))
                {
                    throw new Exception("The input could not be parsed.");
                }

                coordinate.Latitude = latitude;
                coordinate.Longitude = longitude;

                return coordinate;



            }
            throw new Exception("You must provide exactly two comma seperated values.");
        }
    }
}

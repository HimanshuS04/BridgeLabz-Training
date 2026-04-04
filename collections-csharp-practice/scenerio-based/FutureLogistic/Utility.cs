using System.Text.RegularExpressions;

class Utility
{
    public static GoodsTransport parseDetails(string input)
    {
        string[] data = input.Split(':');

        string transportId = data[0];
        string date = data[1];
        int rating = int.Parse(data[2]);
        string type = data[3];

        if (!validateTransportId(transportId))
        {
            Console.WriteLine("Transport id " + transportId + " is invalid");
            Console.WriteLine("Please provide a valid record");
            return null;
        }

        if (type.Equals("BrickTransport", StringComparison.OrdinalIgnoreCase))
        {
            return new BrickTransport(
                transportId, date, rating,
                float.Parse(data[4]),
                int.Parse(data[5]),
                float.Parse(data[6])
            );
        }
        else if (type.Equals("TimberTransport", StringComparison.OrdinalIgnoreCase))
        {
            return new TimberTransport(
                transportId, date, rating,
                float.Parse(data[4]),
                float.Parse(data[5]),
                data[6],
                float.Parse(data[7])
            );
        }

        return null;
    }

    public static bool validateTransportId(string transportId)
    {
        Regex r = new Regex("^RTS[0-9]{3}[A-Z]$");
        return r.IsMatch(transportId);
    }

    public static string findObjectType(GoodsTransport obj)
    {
        if (obj is TimberTransport)
            return "TimberTransport";
        else if (obj is BrickTransport)
            return "BrickTransport";
        else
            return "";
    }

    public static float GetVehiclePrice(string vehicle)
    {
        if (vehicle.Equals("Truck", StringComparison.OrdinalIgnoreCase))
            return 1000;
        else if (vehicle.Equals("Lorry", StringComparison.OrdinalIgnoreCase))
            return 1700;
        else
            return 3000;
    }
}

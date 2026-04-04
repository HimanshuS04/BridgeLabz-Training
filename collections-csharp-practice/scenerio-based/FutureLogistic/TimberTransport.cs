class TimberTransport : GoodsTransport
{
    private float timberLength;
    private float timberRadius;
    private string timberType;
    private float timberPrice;

    public TimberTransport(string transportId, string transportDate, int transportRating,
                           float timberLength, float timberRadius,
                           string timberType, float timberPrice)
        : base(transportId, transportDate, transportRating)
    {
        this.timberLength = timberLength;
        this.timberRadius = timberRadius;
        this.timberType = timberType;
        this.timberPrice = timberPrice;
    }

    public string TimberType
    {
        get { return timberType; }
    }

    public float TimberPrice
    {
        get { return timberPrice; }
    }

    public override string vehicleSelection()
    {
        float area = 2 * 3.147f * timberRadius * timberLength;

        if (area < 250)
            return "Truck";
        else if (area <= 400)
            return "Lorry";
        else
            return "MonsterLorry";
    }

    public override float calculateTotalCharge()
    {
        float volume = 3.147f * timberRadius * timberRadius * timberLength;

        float rate;
        if (timberType.Equals("Premium", StringComparison.OrdinalIgnoreCase))
            rate = 0.25f;
        else
            rate = 0.15f;

        float price = volume * timberPrice * rate;
        float tax = price * 0.3f;

        float discount = 0;
        if (transportRating == 5)
            discount = price * 0.20f;
        else if (transportRating == 3 || transportRating == 4)
            discount = price * 0.10f;

        float vehicleCost = Utility.GetVehiclePrice(vehicleSelection());

        return (price + tax + vehicleCost) - discount;
    }
}

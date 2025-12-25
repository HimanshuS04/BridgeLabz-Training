using System;
class UnitConvertor
{
    //  Kilometers to Miles
    public static double ConvertKmToMiles(double km)
    {
        double km2miles = 0.621371;
        return km * km2miles;
    }

    //  Miles to Kilometers
    public static double ConvertMilesToKm(double miles)
    {
        double miles2km = 1.60934;
        return miles * miles2km;
    }

    //  Meters to Feet
    public static double ConvertMetersToFeet(double meters)
    {
        double meters2feet = 3.28084;
        return meters * meters2feet;
    }

    //  Feet to Meters
    public static double ConvertFeetToMeters(double feet)
    {
        double feet2meters = 0.3048;
        return feet * feet2meters;
    }

    // Yards to Feet
    public static double ConvertYardsToFeet(double yards)
    {
        double yards2feet = 3;
        return yards * yards2feet;
    }

    // Feet to Yards
    public static double ConvertFeetToYards(double feet)
    {
        double feet2yards = 0.333333;
        return feet * feet2yards;
    }

    //  Meters to Inches
    public static double ConvertMetersToInches(double meters)
    {
        double meters2inches = 39.3701;
        return meters * meters2inches;
    }

    //  Inches to Meters
    public static double ConvertInchesToMeters(double inches)
    {
        double inches2meters = 0.0254;
        return inches * inches2meters;
    }

    //  Inches to Centimeters
    public static double ConvertInchesToCentimeters(double inches)
    {
        double inches2cm = 2.54;
        return inches * inches2cm;
    }

    //  Fahrenheit to Celsius
    public static double ConvertFahrenheitToCelsius(double fahrenheit)
    {
        double fahrenheit2celsius = (fahrenheit - 32) * 5 / 9;
        return fahrenheit2celsius;
    }

    //  Celsius to Fahrenheit
    public static double ConvertCelsiusToFahrenheit(double celsius)
    {
        double celsius2fahrenheit = (celsius * 9 / 5) + 32;
        return celsius2fahrenheit;
    }

    //  Pounds to Kilograms
    public static double ConvertPoundsToKilograms(double pounds)
    {
        double pounds2kilograms = 0.453592;
        return pounds * pounds2kilograms;
    }

    //  Kilograms to Pounds
    public static double ConvertKilogramsToPounds(double kilograms)
    {
        double kilograms2pounds = 2.20462;
        return kilograms * kilograms2pounds;
    }

    //  Gallons to Liters
    public static double ConvertGallonsToLiters(double gallons)
    {
        double gallons2liters = 3.78541;
        return gallons * gallons2liters;
    }

    //  Liters to Gallons
    public static double ConvertLitersToGallons(double liters)
    {
        double liters2gallons = 0.264172;
        return liters * liters2gallons;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("10 km in miles: " + UnitConvertor.ConvertKmToMiles(10));
        Console.WriteLine("5 miles in km: " + UnitConvertor.ConvertMilesToKm(5));
        Console.WriteLine("3 meters in feet: " + UnitConvertor.ConvertMetersToFeet(3));
        Console.WriteLine("10 feet in meters: " + UnitConvertor.ConvertFeetToMeters(10));

        Console.WriteLine("5 yards in feet: " + UnitConvertor.ConvertYardsToFeet(5));
        Console.WriteLine("12 feet in yards: " + UnitConvertor.ConvertFeetToYards(12));
        Console.WriteLine("2 meters in inches: " + UnitConvertor.ConvertMetersToInches(2));
        Console.WriteLine("20 inches in meters: " + UnitConvertor.ConvertInchesToMeters(20));
        Console.WriteLine("10 inches in centimeters: " + UnitConvertor.ConvertInchesToCentimeters(10));

        Console.WriteLine("98.6°F in Celsius: " + UnitConvertor.ConvertFahrenheitToCelsius(98.6));

        Console.WriteLine("37°C in Fahrenheit: " + UnitConvertor.ConvertCelsiusToFahrenheit(37));

        Console.WriteLine("150 pounds in kilograms: " + UnitConvertor.ConvertPoundsToKilograms(150));

        Console.WriteLine("70 kilograms in pounds: " + UnitConvertor.ConvertKilogramsToPounds(70));

        Console.WriteLine("5 gallons in liters: " + UnitConvertor.ConvertGallonsToLiters(5));

        Console.WriteLine("10 liters in gallons: " + UnitConvertor.ConvertLitersToGallons(10));
    }
}